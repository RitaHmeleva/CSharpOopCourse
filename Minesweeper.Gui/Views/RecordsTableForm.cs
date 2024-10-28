namespace Minesweeper.Gui.Views;

public partial class RecordsTableForm : Form
{
    public List<(string Level, int Time, string GamerName)>? Records { get; set; }

    public RecordsTableForm()
    {
        InitializeComponent();
    }

    private void RecordsTableForm_Load(object sender, EventArgs e)
    {
        gvRecords.DataSource = Records?.Select(r => new { r.Level, r.Time, r.GamerName }).ToList();
    }
}