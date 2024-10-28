using System.Runtime.Serialization.Formatters.Binary;

namespace Minesweeper.Logic.Models;

public class GameModel : IGameModel
{
    public int RowsCount { get; set; }

    public int ColumnsCount { get; set; }

    public int MinesCount { get; set; }

    public int OpenCellsCount { get; set; }

    private Cell[,]? _cells;

    private GameLevel[] _gameLevels = new GameLevel[]
    {
        new GameLevel("Новичок", 9, 9, 10),
        new GameLevel("Любитель", 16, 16, 40),
        new GameLevel("Профессионал", 16, 30, 100),
        new GameLevel("Настраиваемый", 0, 0, 0)
    };

    private List<GameRecord> _gameRecords = new List<GameRecord>();

    public event EventHandler<int[]>? MinesAroundCounted;

    public event Action<(int RowIndex, int ColumnIndex, bool HasFlag)>? FlagToggled;

    public event Action<(int RowIndex, int ColumnIndex, int minesAroundCount)>? CellOpened;

    public event Action? FieldCreated;

    public event Action<(int RowIndex, int ColumnIndex)>? GameLost;

    public event Action<(int RowIndex, int ColumnIndex, bool HasFlag)>? MineOpened;

    public event Action? GameWon;

    public GameModel()
    {
        if (File.Exists("records"))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("records", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                _gameRecords = (List<GameRecord>)formatter.Deserialize(stream);
            }
        }
        else
        {
            _gameRecords.Add(new GameRecord("Аноним", _gameLevels[0], 9999));
            _gameRecords.Add(new GameRecord("Аноним", _gameLevels[1], 9999));
            _gameRecords.Add(new GameRecord("Аноним", _gameLevels[2], 9999));

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("records", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, _gameRecords);
            }
        }
    }

    public void CreateField(int rowsCount, int columnsCount, int minesCount)
    {
        RowsCount = rowsCount;
        ColumnsCount = columnsCount;
        MinesCount = minesCount;

        OpenCellsCount = 0;

        _cells = new Cell[rowsCount, columnsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                _cells[i, j] = new Cell(false);
            }
        }

        Random random = new Random(DateTime.Now.Second);

        int count = 0;
        int row;
        int column;

        while (count < minesCount)
        {
            row = random.Next(0, rowsCount - 1);
            column = random.Next(0, columnsCount - 1);

            if (!_cells[row, column].HasMine)
            {
                _cells[row, column].HasMine = true;
                count++;
            }
        }

        FieldCreated?.Invoke();
    }

    public GameLevel[] GetLevels()
    {
        return _gameLevels;
    }

    public bool IsGameRecord(int gameTime)
    {
        int recordIndex = _gameRecords.FindIndex(r => r.Level.RowsCount == RowsCount && r.Level.ColumnsCount == ColumnsCount && r.Level.MinesCount == MinesCount);

        return recordIndex < 0 || gameTime < _gameRecords[recordIndex].Time;
    }

    public void SaveRecord(string gamerName, int gameTime)
    {
        int recordIndex = _gameRecords.FindIndex(r => r.Level.RowsCount == RowsCount && r.Level.ColumnsCount == ColumnsCount && r.Level.MinesCount == MinesCount);

        if (recordIndex < 0)
        {
            _gameRecords.Add(new GameRecord(gamerName, new GameLevel("", RowsCount, ColumnsCount, MinesCount), gameTime));
        }
        else if (gameTime < _gameRecords[recordIndex].Time)
        {
            _gameRecords[recordIndex].UserName = gamerName;
            _gameRecords[recordIndex].Time = gameTime;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (Stream stream = new FileStream("records", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, _gameRecords);
        }
    }

    public List<(string Level, int Time, string GamerName)> GetRecordsTable()
    {
        int d = _gameRecords.Count;

        List<(string Level, int Time, string GamerName)> recordsTable =
            _gameRecords
            .Select(r => (string.IsNullOrEmpty(r.Level.Name) ? $"{r.Level.RowsCount}x{r.Level.ColumnsCount}, {r.Level.MinesCount} mine(s)" : r.Level.Name,
            r.Time, r.UserName))
            .ToList();

        return recordsTable;
    }

    public void ToggleFlag(int row, int column)
    {
        _cells![row, column].HasFlag = !_cells[row, column].HasFlag;

        FlagToggled?.Invoke((row, column, _cells[row, column].HasFlag));
    }


    private void MakeCellOpened(int RowIndex, int ColumnIndex, int minesCount)
    {
        CellOpened?.Invoke((RowIndex, ColumnIndex, minesCount));

        OpenCellsCount++;

        if (OpenCellsCount == RowsCount * ColumnsCount - MinesCount)
        {
            GameWon?.Invoke();

            return;
        }
    }

    public void OpenCell(int row, int column)
    {
        if (_cells![row, column].HasMine)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (_cells[i, j].HasMine)
                    {
                        MineOpened?.Invoke((i, j, _cells[i, j].HasFlag));
                    }
                }
            }

            GameLost?.Invoke((row, column));

            return;
        }

        int minesCount;

        var queue = new Queue<(int RowIndex, int ColumnIndex)>();

        queue.Enqueue((row, column));

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();

            if (!_cells[cell.RowIndex, cell.ColumnIndex].IsOpen)
            {
                _cells[cell.RowIndex, cell.ColumnIndex].IsOpen = true;

                minesCount = CountMinesAround(cell.RowIndex, cell.ColumnIndex);

                MakeCellOpened(cell.RowIndex, cell.ColumnIndex, minesCount);

                if (minesCount == 0)
                {
                    WalkAround(cell.RowIndex, cell.ColumnIndex, (i, j) =>
                    {
                        if (!_cells[i, j].HasMine && !_cells[i, j].IsOpen && !queue.Contains((i, j)))
                        {
                            queue.Enqueue((i, j));
                        }
                    });
                }
            }
        }
    }

    private int CountMinesAround(int row, int column)
    {
        int count = 0;

        WalkAround(row, column, (i, j) =>
        {
            if (_cells![i, j].HasMine)
            {
                count++;
            }

        });

        return count;
    }

    private void WalkAround(int row, int column, Action<int, int> action)
    {
        for (int i = row - 1; i <= row + 1; i++)
        {
            if (i < 0 || i == RowsCount)
            {
                continue;
            }

            for (int j = column - 1; j <= column + 1; j++)
            {
                if (j < 0 || j == ColumnsCount || (i == row && j == column))
                {
                    continue;
                }

                action(i, j);
            }
        }
    }
}