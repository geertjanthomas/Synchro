using LocalDeploy.Helper;

namespace LocalDeploy.Forms;

public partial class LoadSdd : Form
{
    public LoadSdd()
    {
        InitializeComponent();
    }

    private void CloseForm_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void StartLoad_Click(object sender, EventArgs e)
    {
        var loader = new LocalSddLoader(SqlServerInstance.Text, SddLoaderCallback);
        if (optLRDW.Checked)
        {
            loader.LoadLrdwReferenceData();
        }
        else if (optRDW.Checked)
        {
            loader.LoadRdwStaticData();
        }
        else if (optRDWConfig.Checked)
        {
            loader.LoadRdwConfiguration();
        }
    }

    private void SddLoaderCallback(string message, bool finished = false)
    {
        if (Messages.InvokeRequired)
        {
            Messages.Invoke(new MethodInvoker(delegate { Messages.Text = $"{message}\r\n{Messages.Text}"; }));
            if (finished)
            {
                StartLoad.Invoke(new MethodInvoker(delegate { StartLoad.Enabled = true; }));
            }
        }
        else
        {
            Messages.Text = $"{message}\r\n{Messages.Text}";
            StartLoad.Enabled = true;
        }
    }

}