using LocalDeploy.Helper;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace LocalDeploy.Forms;

public class BaseDeploymentForm : BaseForm
{
    protected string DeploymentOptionsFile = string.Empty;
    protected Options RawOptions = new();

    protected IEnumerable<CheckBox> GetTaggedCheckboxes()
    {
        var taggedCheckboxes = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Select(f => f.GetValue(this) as CheckBox)
            .Where(chk => !string.IsNullOrEmpty(chk?.SafeTag()))
            .Cast<CheckBox>();
        return taggedCheckboxes;
    }

    protected IEnumerable<RadioButton> GetTaggedRadioButtons()
    {
        var taggedRadioButtons = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Select(f => f.GetValue(this) as RadioButton)
            .Where(radio => !string.IsNullOrEmpty(radio?.SafeTag()))
            .Cast<RadioButton>();
        return taggedRadioButtons;
    }

    protected void SaveVariables(string filename)
    {
        var variableList = Controls.Find("Variables", true).FirstOrDefault() as ListView;
        if (variableList == null) return;
        var variables = variableList.Items.Cast<ListViewItem>()
            .ToDictionary(item => item.Text, item => item.SubItems[1].Text);

        ObjectToJsonFile(variables, filename);
    }

    protected void SaveOptions(string filename)
    {
        var options = new Dictionary<string, object>();
        AddCustomOptions(options);

        RawOptions.DeploymentOptions = options;

        ObjectToJsonFile(RawOptions, filename);
    }

    protected virtual void AddCustomOptions(Dictionary<string, object> options)
    {
        throw new Exception($"Not Implemented : {nameof(AddCustomOptions)}");
    }

    protected Dictionary<string, bool> SelectObjects(Dictionary<string, bool>? selection, string defaultConfiguration)
    {
        var dlg = new SelectObjectsForDeployment
        {
            Options = selection ?? ConfigurationManager.AppSettings[defaultConfiguration]?
                .Split([';'], StringSplitOptions.RemoveEmptyEntries).ToDictionary(s => s, _ => true) ?? new Dictionary<string, bool>()
        };

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            return dlg.Options;
        }

        return selection ?? new Dictionary<string, bool>();
    }

    protected void DrawButtonBorder(Graphics? graphics, Button? btn, Color color)
    {
        if (btn == null || graphics == null) return;

        var w = 3;
        ControlPaint.DrawBorder(graphics, btn.ClientRectangle,
            color, w, ButtonBorderStyle.Solid,
            color, w, ButtonBorderStyle.Solid,
            color, w, ButtonBorderStyle.Solid,
            color, w, ButtonBorderStyle.Solid
        );
    }

    protected void RedBorderWhenNotAllSelected(object sender, Graphics graphics, Dictionary<string, bool> selection)
    {
        if (sender is Button button)
        {
            if (selection.Any(kvp => !kvp.Value))
            {
                DrawButtonBorder(graphics, button, Color.Red);
            }
        }
    }

    protected virtual void ReadDeploymentOptions<T>(string filename) where T : Options
    {
        CheckBaseFile(filename);
        var json = File.ReadAllText(filename);
        try
        {
            var tmp = JsonConvert.DeserializeObject<T>(json);
            RawOptions = tmp ?? throw new Exception($"Could not deserialize Options from '{json}'");
        }
        catch (Exception)
        {
            RawOptions = new Options
            {
                DeploymentOptions = JsonConvert.DeserializeObject<Dictionary<string, object>>(json)
            };
        }

        // Get all boolean options
        var options = RawOptions
            .DeploymentOptions
            ?.Where(kvp => bool.TryParse(kvp.Value.ToString(), out _))
            .ToDictionary(kvp => kvp.Key, kvp => bool.Parse(kvp.Value.ToString() ?? false.ToString()));

        GetTaggedCheckboxes()
            .ForEach(chk =>
            {
                var key = chk.SafeTag();
                if (options?.ContainsKey(key) ?? false)
                {
                    chk.Checked = options[key];
                }
            });

        GetTaggedRadioButtons()
            .ForEach(opt =>
            {
                var key = opt.SafeTag().Split(':');
                if (options?.ContainsKey(key[0]) ?? false)
                {
                    if (bool.Parse(key[1]))
                        opt.Checked = options[key[0]];
                    else
                        opt.Checked = !options[key[0]];
                }
            });

    }

    protected void RunScript(string scriptConfig, string? branch = null)
    {
        if (!IsAdministrator())
        {
            // Restart the application with elevated privileges
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe"),
                Verb = "runas"
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"The application needs to be run as an administrator. {ex.Message}");
            }

            Close();
            return;
        }

        SaveOptions(DeploymentOptionsFile);
        SaveVariables(LocalOveridesFile);

        var scriptArgs =  $" -branch {branch}";

        RunPowershellScript(scriptConfig, scriptArgs);

        Close();
    }

    protected bool IsAdministrator()
    {
        var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
        var principal = new System.Security.Principal.WindowsPrincipal(identity);
        return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
    }

    public static void RunPowershellScript(string scriptConfig, string? scriptArguments = null, bool hideWindow = false)
    {
        var scriptName = Program.Configuration[scriptConfig];
        if (scriptName == null)
        {
            throw new Exception($"No appseting found: '{scriptConfig}'");
        }

        var program = @"powershell.exe";
        var arguments = $"-ExecutionPolicy RemoteSigned -File \"{scriptName}\" {scriptArguments}";

        var startInfoScript = new ProcessStartInfo(program, arguments)
        {
            Verb = "runas",
        };

        if (hideWindow)
        {
            startInfoScript.CreateNoWindow = true;
            startInfoScript.UseShellExecute = false;
            startInfoScript.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoScript.RedirectStandardOutput = true;
            startInfoScript.RedirectStandardError = true;
        }

        Process.Start(startInfoScript);
    }
}