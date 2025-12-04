namespace LocalDeploy.Forms;

public partial class ResetWarning : Form
{
    public ResetWarning()
    {
        InitializeComponent();
    }

    private void ResetWarning_Load(object sender, EventArgs e)
    {
        Warning.Text = @"Are you sure you want to reset the local deployment of RDW?

This will remove:
- All databases related to RDW
- All SSIS packages, projects and environments
- All Reporting Services reports, data sources and folders
- The StaticDataDepot database
- All local RDW components in C:\localdeploy
- All downloaded build and release artifacts in C:\Temp

You can follow the First Time Instructions to redeploy RDW after this reset.
";
    }
}