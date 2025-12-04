namespace LocalDeploy.Forms;

public partial class Instructions : Form
{
    public Instructions()
    {
        InitializeComponent();
    }

    private void Instructions_Load(object sender, EventArgs e)
    {
        var assemblyFolder = new FileInfo(GetType().Assembly.Location).DirectoryName;

        var pathToInstructionsFile = Path.Join(assemblyFolder, "FirstTimeInstructions.mht");

        webBrowser.Navigate($"file://{pathToInstructionsFile}");

    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            Close();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}