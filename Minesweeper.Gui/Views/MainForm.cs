namespace Minesweeper.Gui.Views;

public partial class MainForm : Form, IMainForm
{
    private ImageList _imageList;

    private int _cellSize;

    private CellImageIndex[,]? _imageIndexes;

    private List<GameLevel>? _gameLevels;

    private ToolStripMenuItem? _previousLevelItemChecked;

    private int GameTime { get; set; }

    private int GameMinesCount { get; set; }

    private int RowsCount { get; set; }

    private int ColumnsCount { get; set; }

    private int MinesCount { get; set; }

    private string GamerName { get; set; } = "Аноним";

    private List<Image> images;
    private List<Image> imagesSmall = new List<Image>();
    private List<Image> imagesMedium = new List<Image>();

    public event Action<int, int>? ToggleFlag;

    public event Action? StartNewGame;

    public event Action<string, int, int, int, int>? SendGame;

    public event Action<int, int>? OpenCell;

    public event Action<(int RowsCount, int ColumnsCount, int MinesCount)>? GameLevelSelected;

    public event Action? RecordsTableRequested;

    public MainForm()
    {
        InitializeComponent();

        foreach (var image in imageListMedium.Images)
        {
            imagesMedium.Add((Image)image);
        }

        foreach (var image in imageListSmall.Images)
        {
            imagesSmall.Add((Image)image);
        }

        images = imagesMedium;

        _imageList = imageListMedium;

        _cellSize = imageListMedium.ImageSize.Width;

        pnField.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 200);
        pnField.MinimumSize = new Size(faceButton.Width + pbTimer.Width + pbMine.Width + 160, 0);
        pnField.AutoSize = true;
        pnField.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        tmGame.Enabled = false;
        tmGame.Interval = 1000;
        tmGame.Tick += tmGame_Tick;
    }

    private void tmGame_Tick(object? sender, EventArgs e)
    {
        GameTime++;

        lbTime.Text = GameTime.ToString();
    }

    public void AddLevel(string name, int rowsCount, int columnsCount, int minesCount)
    {
        if (_gameLevels is null)
        {
            _gameLevels = new List<GameLevel>();
        }

        _gameLevels.Add(new GameLevel(name, rowsCount, columnsCount, minesCount));

        ToolStripMenuItem mi = new ToolStripMenuItem(name);

        mi.Click += LevelMenuItemClick;

        if (_previousLevelItemChecked is null)
        {
            mi.Checked = true;
            _previousLevelItemChecked = mi;

            mi.PerformClick();
        }

        miGame.DropDownItems.Insert(miGame.DropDownItems.Count - 4, mi);
    }

    private void LevelMenuItemClick(object? sender, EventArgs e)
    {
        (sender as ToolStripMenuItem)!.Checked = true;

        if (_previousLevelItemChecked is not null && _previousLevelItemChecked != (sender as ToolStripMenuItem))
        {
            _previousLevelItemChecked.Checked = false;
        }

        _previousLevelItemChecked = sender as ToolStripMenuItem;

        int levelIndex = _gameLevels!.FindIndex(e => e.Name == (sender as ToolStripMenuItem)!.Text);

        if (levelIndex > -1)
        {
            GameLevel level = _gameLevels[levelIndex];

            if (level.RowsCount > 0 && level.ColumnsCount > 0)
            {
                RowsCount = level.RowsCount;
                ColumnsCount = level.ColumnsCount;
                MinesCount = level.MinesCount;

                StartGame();
            }
            else
            {
                LevelForm form = new LevelForm();

                form.RowsCount = RowsCount;
                form.ColumnsCount = ColumnsCount;
                form.MinesCount = MinesCount;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    RowsCount = form.RowsCount;
                    ColumnsCount = form.ColumnsCount;
                    MinesCount = form.MinesCount;

                    StartGame();
                }
            }
        }
    }

    private async void StartGame()
    {
        faceButton.ImageIndex = 0;

        Cursor = Cursors.WaitCursor;

        pbField.Enabled = false;

        GameTime = 0;
        GameMinesCount = MinesCount;

        lbMinesCount.Text = MinesCount.ToString();
        lbTime.Text = "0";

        tmGame.Enabled = false;

        GameLevelSelected?.Invoke((RowsCount, ColumnsCount, MinesCount));
    }

    public async Task SetGameReady()
    {
        await CreateField();

        pbField.Enabled = true;

        Cursor = Cursors.Default;
    }

    public async Task CreateField()
    {
        if (RowsCount > 20 || ColumnsCount > 40)
        {
            images = imagesSmall;
            _cellSize = imageListSmall.ImageSize.Width;
        }
        else
        {
            images = imagesMedium;
            _cellSize = imageListMedium.ImageSize.Width;
        }

        if (_imageIndexes == null || _imageIndexes.GetLength(0) != RowsCount || _imageIndexes.GetLength(1) != ColumnsCount)
        {
            _imageIndexes = new CellImageIndex[RowsCount, ColumnsCount];
        }

        if (pbField.Image == null || pbField.Image.Height != RowsCount * _cellSize || pbField.Image.Width != ColumnsCount * _cellSize)
        {
            pbField.Image = new Bitmap(ColumnsCount * _cellSize, RowsCount * _cellSize);
        }

        pbField.Size = new Size(ColumnsCount * _cellSize + 4, RowsCount * _cellSize + 4);

        pbField.Location = new Point(0, 0);
        if (pbField.Width < pnField.Width)
        {
            pbField.Location = new Point((pnField.Width - pbField.Width) / 2, 0);
        }

        using (Graphics graphics = Graphics.FromImage(pbField.Image))
        {
            await CreateFieldAsync(RowsCount, ColumnsCount, graphics);
        }

        pbField.Invalidate();
    }

    private void CreateField(int rowsCount, int columnsCount, Graphics graphics)
    {
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                _imageIndexes![i, j] = CellImageIndex.Closed;
            }
        }

        for (int i = 0; i < _imageIndexes!.GetLength(0); i++)
        {
            for (int j = 0; j < _imageIndexes.GetLength(1); j++)
            {
                graphics.DrawImage(images[(int)CellImageIndex.Closed], j * _cellSize, i * _cellSize);
            }
        }
    }

    private async Task CreateFieldAsync(int rowsCount, int columnsCount, Graphics graphics)
    {
        await Task.Run(() =>
        {
            CreateField(rowsCount, columnsCount, graphics);
        });
    }

    private void miNewGame_Click(object sender, EventArgs e)
    {
        StartGame();
    }

    public void SetFlag(int rowIndex, int columnIndex, bool hasFlag)
    {
        if (hasFlag)
        {
            _imageIndexes![rowIndex, columnIndex] = CellImageIndex.Flag;

            GameMinesCount--;
        }
        else
        {
            _imageIndexes![rowIndex, columnIndex] = CellImageIndex.Closed;

            GameMinesCount++;
        }

        lbMinesCount.Text = GameMinesCount.ToString();

        RedrawCell(rowIndex, columnIndex);
    }

    public void CellOpenedHandler(int rowIndex, int columnIndex, int minesCount)
    {
        _imageIndexes![rowIndex, columnIndex] = (CellImageIndex)minesCount;
        RedrawCell(rowIndex, columnIndex);
    }

    private void RedrawCell(int row, int column)
    {
        using (Graphics graphics = Graphics.FromImage(pbField.Image))
        {
            graphics.DrawImage(images[(int)_imageIndexes![row, column]], column * _cellSize, row * _cellSize);
        }

        pbField.Invalidate(new Rectangle(column * _cellSize, row * _cellSize, _cellSize, _cellSize));
    }

    public void SetGameLost(int row, int column)
    {
        _imageIndexes![row, column] = CellImageIndex.Boom;
        RedrawCell(row, column);

        tmGame.Enabled = false;
        faceButton.ImageIndex = 3;

        pbField.Enabled = false;

        MessageBox.Show("Игра проиграна", "Сапёр", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public int SetGameWon()
    {
        tmGame.Enabled = false;

        faceButton.ImageIndex = 4;

        pbField.Enabled = false;

        MessageBox.Show("Игра выиграна", "Сапёр", MessageBoxButtons.OK, MessageBoxIcon.Information);

        return GameTime;
    }

    public string GetGamer()
    {
        GamerForm form = new GamerForm();

        form.GamerName = GamerName;

        form.ShowDialog();

        GamerName = form.GamerName;

        return GamerName;
    }

    public void OpenMine(int rowIndex, int columnIndex, bool hasFlag)
    {
        _imageIndexes![rowIndex, columnIndex] = hasFlag ? CellImageIndex.Mistake : CellImageIndex.Mine;
        RedrawCell(rowIndex, columnIndex);
    }

    private void faceButton_Click(object sender, EventArgs e)
    {
        StartGame();
    }

    private void miAbout_Click(object sender, EventArgs e)
    {
        MessageBox.Show("«Сапёр» (англ. Minesweeper) — игра-головоломка, главной задачей которой является найти все «заминированные» клетки.", "Сапёр", MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    private void miExit_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Вы действительно хотите выйти из игры?", "Сапёр", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            Close();
        }
    }

    private void pbField_MouseClick(object sender, MouseEventArgs e)
    {
        int row = e.Y / _cellSize;
        int column = e.X / _cellSize;

        if (!tmGame.Enabled)
        {
            tmGame.Enabled = true;
        }

        if (e.Button == MouseButtons.Left)
        {
            if (_imageIndexes![row, column] == CellImageIndex.Closed)
            {
                OpenCell?.Invoke(row, column);
            }
        }
        else if (e.Button == MouseButtons.Right)
        {
            if (_imageIndexes![row, column] == CellImageIndex.Closed || _imageIndexes[row, column] == CellImageIndex.Flag)
            {
                ToggleFlag?.Invoke(row, column);
            }
        }
    }

    private void miRecords_Click(object sender, EventArgs e)
    {
        RecordsTableRequested?.Invoke();
    }

    public void ShowRecordsTable(List<(string Level, int Time, string GamerName)> records)
    {
        RecordsTableForm form = new RecordsTableForm();

        form.Records = records;

        form.ShowDialog();
    }
}