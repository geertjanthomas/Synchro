using System.Reflection;
using LocalDeploy.Helper;

namespace LocalDeploy.Forms;

public partial class LrdwDeploymentDashboard : BaseDeploymentForm
{
    public LrdwDeploymentDashboard()
    {
        InitializeComponent();
        RawOptions = new LrdwOptions();

        GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Select(f => f.GetValue(this) as Control)
            .Where(ctl => ctl != null).Cast<Control>()
            .ToList()
            .ForEach(ctl =>
            {
                ctl.MouseEnter += Control_UpdateExplanation;
                ctl.MouseLeave += Control_MouseLeave;
            });

        DeploymentOptionsFile = Program.Configuration["LrdwDeploymentOptionsFile"] ?? throw new Exception("LrdwDeploymentOptionsFile missing from appsettings.json");
        LocalOveridesFile = Program.Configuration["LocalOveridesFile"] ?? throw new Exception("LocalOveridesFile missing from appsettings.json");
    }

    private void Form_Load(object sender, EventArgs e)
    {
        ReadDeploymentOptions<LrdwOptions>(DeploymentOptionsFile);
        ProcessLocalOverrides(LocalOveridesFile);

        Explanation.Text = "";
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        RunScript("LrdwPowershellScript", optCustomBranch.Checked ? CustomBranch.Text : "master");
    }

    private void btnSaveOptions_Click(object sender, EventArgs e)
    {
        SaveOptions(DeploymentOptionsFile);
        SaveVariables(LocalOveridesFile);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    protected override void ReadDeploymentOptions<T>(string filename)
    {
        base.ReadDeploymentOptions<T>(filename);
        chkDownloadArtifacts_CheckedChanged(chkDownloadArtifacts, null);
    }

    protected override void AddCustomOptions(Dictionary<string, object> options)
    {
        var checks = GetTaggedCheckboxes()
            .ToDictionary(chk => chk.SafeTag(), chk => (object)chk.Checked);
        foreach (var kvp in checks)
        {
            options.Add(kvp.Key, kvp.Value);
        }

        GetTaggedRadioButtons()
            .Where(radio => radio.SafeTag().Contains("True"))
            .ToDictionary(radio => radio.SafeTag().Split(':')[0], radio => (object)radio.Checked)
            .ToList()
            .ForEach(kvp => options.Add(kvp.Key, kvp.Value));
    }


    private void ProcessLocalOverrides(string filename)
    {
        var variables = ReadLocalOverrides(filename);
        foreach (var kvp in variables)
        {
            Variables.Items.Add(new ListViewItem { Text = kvp.Key, SubItems = { kvp.Value } });
        }
    }

    private void ValueBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
        {
            var idxDelta = e.KeyCode == Keys.Up ? -1 : 1;
            var idx = Variables.SelectedIndices[0];
            var newidx = idx + idxDelta;
            if (newidx >= 0 && newidx < Variables.Items.Count)
            {
                Variables.Items[idx].Selected = false;
                Variables.Items[newidx].Selected = true;
                ShowValueBox();
            }
        }
    }

    private void Variables_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Variables.SelectedItems.Count != 1) return;
        Variables.SelectedItems[0].EnsureVisible();
    }

    private void Variables_MouseClick(object sender, MouseEventArgs e)
    {
        if (Variables.SelectedItems.Count != 1) return;

        if (e.X > Variables.Columns[0].Width)
        {
            ShowValueBox();
        }
    }

    private void HideValueBox()
    {
        ValueBox.Visible = false;
        ValueBox.Text = "";
    }

    private void ShowValueBox()
    {
        var sub = Variables.SelectedItems[0].SubItems[1];

        ValueBox.Top = sub.Bounds.Top + 5;
        ValueBox.Left = sub.Bounds.Left + 8;
        ValueBox.Width = sub.Bounds.Width;
        ValueBox.Text = sub.Text;
        ValueBox.Visible = true;
        ValueBox.Focus();
    }

    private void ValueBox_Leave(object sender, EventArgs e)
    {
        HideValueBox();
    }

    private void ValueBox_TextChanged(object sender, EventArgs e)
    {
        if (Variables.SelectedItems.Count != 1) return;
        if (!ValueBox.Visible) return;

        Variables.SelectedItems[0].SubItems[1].Text = ValueBox.Text;
    }

    private void Control_MouseLeave(object? sender, EventArgs e)
    {
        GetTaggedCheckboxes().ToList().ForEach(cb => cb.BackColor = tabOptions.BackColor);
        Explanation.Text = "";
    }

    private LrdwOptions LrdwOptions => (RawOptions as LrdwOptions) ?? throw new Exception("_rawOptions should be of type LrdwOptions");


    private void Control_UpdateExplanation(object? sender, EventArgs e)
    {
        string text;
        if (sender == chkDownloadArtifacts || sender == DownloadOptions)
            text = "Download the artifacts of the release";
        else if (sender == optMasterBuild)
            text = "If selected, the latest build, for the master branch, will be downloaded";
        else if (sender == optCustomBranch)
            text = "If selected, the latest build from this branch.";
        else if (sender == CustomBranch)
            text = "Provide a specific branch name to get build artefacts from.";
        else if (sender == tabControl1)
            text = tabControl1.SelectedTab == tabVariables
                ? "You can override the default release variables with specific values that match your environment."
                : "";
        else if (sender == btnClose)
            text = "Close this window";
        else if (sender == btnStart)
            text = "Start the deployment";
        else if (sender == btnSaveOptions)
            text = "Only save the options and variables";

        else if (sender == chkCreateDirectories)
            text = "Only save the options and variables";
        else if (sender == chkPreDeploymentScripts)
            text = "Execute scripts before other deployment actions";
        else if (sender == chkPreReleaseScripts)
            text = "Execute release specific scripts before other deployment actions";
        else if (sender == chkDeployCrdwDatabase)
            text = "Deploy CRDW databases";
        else if (sender == chkDeployDatabases)
            text = "Deploy the databases";
        else if (sender == chkDeployIsPacs)
            text = "Deploy the SSIS projects";
        else if (sender == chkPostDeploymentScripts)
            text = "Execute scripts after all other deployment actions";
        else if (sender == chkPostReleaseScripts)
            text = "Execute release specific scripts after all other deployment actions";
        else if (sender == btnSelectCrdwDatabases)
            text = $"Select which CRDW databases should be deployed : {LrdwOptions.CrdwDatabases.Count(kvp => kvp.Value)} / {LrdwOptions.CrdwDatabases.Count}";
        else if (sender == btnSelectDatabases)
            text = $"Select which databases should be deployed : {LrdwOptions.Databases.Count(kvp => kvp.Value)} / {LrdwOptions.Databases.Count}";
        else if (sender == btnSelectIspacs)
            text = $"Select which SSIS projects should be deployed : {LrdwOptions.Ispacs.Count(kvp => kvp.Value)} / {LrdwOptions.Ispacs.Count}";
        else
            text = "";

        Explanation.Text = text;
    }

    private void chkDownloadArtifacts_CheckedChanged(object sender, EventArgs? e)
    {
        DownloadOptions.Enabled = chkDownloadArtifacts.Checked;
    }

    private void btlSelectCrdwDatabases_Click(object sender, EventArgs e)
    {
        LrdwOptions.CrdwDatabases = SelectObjects(LrdwOptions.CrdwDatabases, "LrdwDacpacsCrdw");
    }

    private void btlSelectDatabases_Click(object sender, EventArgs e)
    {
        LrdwOptions.Databases = SelectObjects(LrdwOptions.Databases, "LrdwDacpacs");
    }

    private void btnSelectIspacs_Click(object sender, EventArgs e)
    {
        LrdwOptions.Ispacs = SelectObjects(LrdwOptions.Ispacs, "LrdwIspacs");
    }

    private void btlSelectCrdwDatabases_Paint(object sender, PaintEventArgs e)
    {
        RedBorderWhenNotAllSelected(sender, e.Graphics, LrdwOptions.CrdwDatabases);
    }

    private void btlSelectDatabases_Paint(object sender, PaintEventArgs e)
    {
        RedBorderWhenNotAllSelected(sender, e.Graphics, LrdwOptions.Databases);
    }

    private void btnSelectIspacs_Paint(object sender, PaintEventArgs e)
    {
        RedBorderWhenNotAllSelected(sender, e.Graphics, LrdwOptions.Ispacs);
    }

}