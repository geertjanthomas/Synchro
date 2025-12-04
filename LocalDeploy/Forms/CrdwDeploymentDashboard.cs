using System.Reflection;
using LocalDeploy.Helper;

namespace LocalDeploy.Forms;

public partial class CrdwDeploymentDashboard : BaseDeploymentForm
{
    public CrdwDeploymentDashboard()
    {
        InitializeComponent();
        RawOptions = new CrdwOptions();

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

        DeploymentOptionsFile = Program.Configuration["CrdwDeploymentOptionsFile"] ?? throw new Exception("CrdwDeploymentOptionsFile missing from appsettings.json");
        LocalOveridesFile = Program.Configuration["LocalOveridesFile"] ?? throw new Exception("LocalOveridesFile missing from appsettings.json");
    }

    private void Form_Load(object sender, EventArgs e)
    {
        ReadDeploymentOptions<CrdwOptions>(DeploymentOptionsFile);
        ProcessLocalOverrides(LocalOveridesFile);

        Explanation.Text = "";
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        RunScript("CrdwPowershellScript", optCustomBranch.Checked ? CustomBranch.Text : "master");
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

    private void ProcessLocalOverrides(string filename)
    {
        var variables = ReadLocalOverrides(filename);
        foreach (var kvp in variables)
        {
            Variables.Items.Add(new ListViewItem { Text = kvp.Key, SubItems = { kvp.Value } });
        }
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

    private CrdwOptions CrdwOptions => (RawOptions as CrdwOptions) ?? throw new Exception("_rawOptions should be of type CrdwOptions");

    private void btnSelectDatabases_Paint(object sender, PaintEventArgs e)
    {
        RedBorderWhenNotAllSelected(sender, e.Graphics, CrdwOptions.Databases);
    }

    private void btnSelectIspacs_Paint(object sender, PaintEventArgs e)
    {
        RedBorderWhenNotAllSelected(sender, e.Graphics, CrdwOptions.Ispacs);
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

    private void Control_UpdateExplanation(object? sender, EventArgs e)
    {
        string text;
        if (sender == chkDownloadArtifacts || sender == DownloadOptions)
            text = "Download the artifacts of the release";
        else if (sender == chkDependencies)
            text = "Deploy and register all assemblies CRDW depends on, create folder structure if necessary";
        else if (sender == chkDeployDatabases)
            text = "Deploy the databases";
        else if (sender == chkDeployIsPacs)
            text = "Deploy the SSIS projects";
        else if (sender == chkReports)
            text = "Deploy reports";
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
        else if (sender == btnSelectDatabases)
            text = $"Select which databases should be deployed : {CrdwOptions.Databases.Count(kvp => kvp.Value)} / {CrdwOptions.Databases.Count}";
        else if (sender == btnSelectIspacs)
            text = $"Select which ispacs should be deployed : {CrdwOptions.Ispacs.Count(kvp => kvp.Value)} / {CrdwOptions.Ispacs.Count}";
        else if (sender == chkPreReleaseScripts)
            text = "Execute release specific scripts before other deployment actions";
        else if (sender == chkPostReleaseScripts)
            text = "Execute release specific scripts after all other deployment actions";
        else if (sender == chkPreDeploymentScripts)
            text = "Execute scripts before other deployment actions";
        else if (sender == chkPostDeploymentScripts)
            text = "Execute scripts after all other deployment actions";
        else
            text = "";

        Explanation.Text = text;
    }

    private void chkDownloadArtifacts_CheckedChanged(object sender, EventArgs? e)
    {
        DownloadOptions.Enabled = chkDownloadArtifacts.Checked;
    }

    private void btnSelectDatabases_Click(object sender, EventArgs e)
    {
        CrdwOptions.Databases = SelectObjects(CrdwOptions.Databases, "CrdwDacpacs");
    }

    private void btnSelectIspacs_Click(object sender, EventArgs e)
    {
        CrdwOptions.Ispacs = SelectObjects(CrdwOptions.Ispacs, "CrdwIspacs");
    }

}