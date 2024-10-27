namespace Minesweeper.Gui.Views;

public partial class RecordsTableForm : Form
{
    public List<(string Level, int Time, string GamerName)> Records { get; set; }

    public RecordsTableForm()
    {
        InitializeComponent();
    }

    private void RecordsTableForm_Load(object sender, EventArgs e)
    {
        foreach (var record in Records)
        {
            gvRecords.Rows.Add(new string[] { record.Level, record.Time.ToString(), record.GamerName });
        }
    }
}