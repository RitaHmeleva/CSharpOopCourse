namespace Minesweeper.Gui.ViewsEventArgs;

public class GameLevelSelectedEventArgs : EventArgs
{
    public int RowsCount { get; set; }

    public int ColumnsCount { get; set; }

    public int MinesCount { get; set; }

    public GameLevelSelectedEventArgs(int rowsCount, int columnsCount, int minesCount)
    {
        RowsCount = rowsCount;
        ColumnsCount = columnsCount;
        MinesCount = minesCount;
    }
}