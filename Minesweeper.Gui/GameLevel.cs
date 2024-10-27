namespace Minesweeper.Gui;

public class GameLevel
{
    public string Name { get; set; }

    public int RowsCount { get; set; }

    public int ColumnsCount { get; set; }

    public int MinesCount { get; set; }

    public GameLevel(string name, int rowsCount, int columnsCount, int minesCount)
    {
        Name = name;
        RowsCount = rowsCount;
        ColumnsCount = columnsCount;
        MinesCount = minesCount;
    }
}