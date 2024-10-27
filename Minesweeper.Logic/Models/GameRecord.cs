namespace Minesweeper.Logic.Models;

[Serializable]
public class GameRecord
{
    public string UserName { get; set; }

    public GameLevel Level { get; set; }

    public int Time { get; set; }

    public GameRecord(string name, GameLevel level, int time)
    {
        UserName = name;
        Level = level;
        Time = time;
    }
}