namespace LocalDeploy.Forms;

public partial class Start : BaseForm
{
    public Start()
    {
        InitializeComponent();
        KeyPreview = true;
        LocalOveridesFile = Program.Configuration["LocalOveridesFile"] ?? throw new Exception("LocalOveridesFile missing from appsettings.json");
    }

    private void Start_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape)
        {
            Application.Exit();
        }
    }

    private void CRDW_Click(object sender, EventArgs e)
    {
        Hide();
        new CrdwDeploymentDashboard().ShowDialog();
        Show();
    }

    private void LRDW_Click(object sender, EventArgs e)
    {
        Hide();
        new LrdwDeploymentDashboard().ShowDialog();
        Show();
    }

    private void Dashboard_Click(object sender, EventArgs e)
    {
        Hide();
        new DashboardDeploymentDashboard().ShowDialog();
        Show();
    }

    private void StaticDataDepot_Click(object sender, EventArgs e)
    {
        Hide();
        new StaticDataDepotDeploymentDashboard().ShowDialog();
        Show();
    }

    private void Kill_Click(object sender, EventArgs e)
    {
        if (new ResetWarning().ShowDialog() == DialogResult.OK)
        {
            if (MessageBox.Show(@"Last chance? Do you wish to proceed?", @"Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                BaseDeploymentForm.RunPowershellScript("ResetPowershellScript");
            }
        }
    }

    private void LaunchDashboard_Click(object sender, EventArgs e)
    {
        BaseDeploymentForm.RunPowershellScript("DashboardLaunchScript", hideWindow: true);
    }

    private void LoadSDD_Click(object sender, EventArgs e)
    {
        Hide();
        new LoadSdd().ShowDialog();
        Show();
    }

    private Instructions? _instructions;
    private void button1_Click(object sender, EventArgs e)
    {
        if (_instructions == null || _instructions.IsDisposed)
        {
            _instructions = new Instructions();
        }
        if (_instructions.Visible)
        {
            _instructions.BringToFront();
        }
        else
        {
            _instructions.Show(this);
            _instructions.Left = Left + Width + 20;
        }
    }

    /// <summary>
    /// Find the best location of the sqlpackage.exe and save it to the local overrides file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Start_Load(object sender, EventArgs e)
    {
        var variables = ReadLocalOverrides(LocalOveridesFile);

        // Four possible locations for sqlpackage.exe
        var filename = "sqlpackage.exe";
        var path2022Ent = @"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\Extensions\Microsoft\SQLDB\DAC";
        var path2022Pro = @"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\Microsoft\SQLDB\DAC";
        var path2019Ent = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\Extensions\Microsoft\SQLDB\DAC";
        var path2019Pro = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\Microsoft\SQLDB\DAC";

        // Locate the newest/best version of sqlpackage.exe
        var sqlPackageLocation = FindFile(path2022Ent, filename) ??
                                 FindFile(path2022Pro, filename) ??
                                 FindFile(path2019Ent, filename) ??
                                 FindFile(path2019Pro, filename);

        // Save the location to the local overrides file
        if (sqlPackageLocation != null)
        {
            variables["SqlPackageLocation"] = sqlPackageLocation;
            ObjectToJsonFile(variables, LocalOveridesFile);
        }
    }

    private string? FindFile(string path, string filename)
    {
        if (Path.Exists(path))
        {
            var files = Directory.GetFiles(path, filename, SearchOption.AllDirectories).ToList();
            if (files.Count > 0)
            {
                return files.OrderByDescending(File.GetLastWriteTime).First();
            }
        }
        return null;
    }
}