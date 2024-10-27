namespace Minesweeper.Gui.Views;

public partial class LevelForm : Form
{
    public int RowsCount { get; set; }

    public int ColumnsCount { get; set; }

    public int MinesCount { get; set; }

    public LevelForm()
    {
        InitializeComponent();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
        if (nmRowsCount.Value * nmColumnsCount.Value * 0.5m < nmMinesCount.Value)
        {
            MessageBox.Show("Задано слишком большое количество мин.", "Сапёр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }

        RowsCount = (int)nmRowsCount.Value;
        ColumnsCount = (int)nmColumnsCount.Value;
        MinesCount = (int)nmMinesCount.Value;

        DialogResult = DialogResult.OK;

        Close();
    }

    private void LevelForm_Load(object sender, EventArgs e)
    {
        nmRowsCount.Value = RowsCount;
        nmColumnsCount.Value = ColumnsCount;
        nmMinesCount.Value = MinesCount;
    }
}