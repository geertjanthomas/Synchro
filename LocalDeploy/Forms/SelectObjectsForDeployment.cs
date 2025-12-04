using LocalDeploy.Helper;

namespace LocalDeploy.Forms;

public partial class SelectObjectsForDeployment : Form
{
    public Dictionary<string, bool> Options { get; set; } = new();

    private List<CheckBox> Checkboxes => Controls.Cast<Control>()
        .Where(c => c is CheckBox box && box != chkAll)
        .Cast<CheckBox>()
        .ToList();


    public SelectObjectsForDeployment(Dictionary<string, bool> options)
    {
        Options = options;
        Initialize();
    }

    public SelectObjectsForDeployment()
    {
        Initialize();
    }

    private void Initialize()
    {
        InitializeComponent();
    }

    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        Checkboxes.ForEach(cb => cb.Checked = chkAll.Checked);
    }

    private void SelectDatabases_Load(object sender, EventArgs e)
    {
        const int checkboxHeight = 24;

        var i = 1;
        Options.OrderBy(kvp => kvp.Key).ForEach(kvp =>
        {
            var cb = new CheckBox
            {
                Name = kvp.Key,
                Text = kvp.Key,
                Checked = kvp.Value
            };
            var loc = chkAll.Location;
            var newLoc = new Point(loc.X + 20, loc.Y + i * checkboxHeight);
            cb.Location = newLoc;
            cb.Size = new Size(350, 17);
            Controls.Add(cb);
            i++;
        });
        Height = 200 + Options.Count * checkboxHeight;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Options = Checkboxes.ToDictionary(c => c.Name, c => c.Checked);
        DialogResult = DialogResult.OK;
        Close();
    }
}