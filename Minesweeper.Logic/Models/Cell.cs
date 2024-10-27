namespace Minesweeper.Logic.Models;

internal class Cell
{
    public bool IsOpen { get; set; }

    public int MinesAroundCount { get; set; }

    public bool HasMine { get; set; }

    public bool HasFlag { get; set; }

    public Cell(bool hasMine) 
    {
        HasMine = hasMine;
        MinesAroundCount = -1;
        IsOpen = false;
        HasFlag = false;
    }
}