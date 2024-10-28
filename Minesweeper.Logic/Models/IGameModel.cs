namespace Minesweeper.Logic.Models;

public interface IGameModel
{
    GameLevel[] GetLevels();

    void CreateField(int rowCount, int columnCount, int mineCount);

    void OpenCell(int row, int column);

    void ToggleFlag(int row, int column);

    bool IsGameRecord(int gameTime);

    void SaveRecord(string gamerName, int gameTime);

    List<(string Level, int Time, string GamerName)> GetRecordsTable();

    event Action FieldCreated;

    event Action<(int RowIndex, int ColumnIndex, bool HasFlag)> FlagToggled;

    event Action<(int RowIndex, int ColumnIndex, int minesAroundCount)>? CellOpened;

    event Action<(int RowIndex, int ColumnIndex)> GameLost;

    event Action GameWon;

    event Action<(int RowIndex, int ColumnIndex, bool HasFlag)> MineOpened;
}