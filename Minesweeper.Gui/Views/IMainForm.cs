namespace Minesweeper.Gui.Views;

public interface IMainForm
{
    void AddLevel(string name, int rowsCount, int columnsCount, int minesCount);

    Task SetGameReady();

    string GetGamer();

    void SetFlag(int rowIndex, int columnIndex, bool hasFlag);

    void CellOpenedHandler(int rowIndex, int columnIndex, int minesCount);

    void ShowRecordsTable(List<(string Level, int Time, string GamerName)> records);

    void SetGameLost(int RowIndex, int ColumnIndex);

    int SetGameWon();

    void OpenMine(int rowIndex, int columnIndex, bool hasFlag);

    event Action<(int RowsCount, int ColumnsCount, int MinesCount)> GameLevelSelected;

    event Action<int, int>? OpenCell;

    event Action<int, int>? ToggleFlag;

    event Action? StartNewGame;

    event Action RecordsTableRequested;
}