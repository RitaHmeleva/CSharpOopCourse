namespace CsvTask;

internal class Row
{
    private const int DefaultCapacity = 10;
    private const int ChangeCapacityStep = 10;

    private readonly string NewLine = Environment.NewLine;

    private Cell[] _cell;

    private string IndentString => new String(' ', Indent);

    public int CellsCount { get; set; }

    public int Indent { get; set; } = 2;

    public int IndentCell { get; set; } = 2;

    public string Html => $"{IndentString}<tr>{NewLine}{string.Join(NewLine, _cell.Take(CellsCount).Select(c => c.Html))}{NewLine}{IndentString}</tr>";

    public Row() : this(DefaultCapacity)
    {
    }

    public Row(int capacity)
    {
        _cell = new Cell[capacity];
        CellsCount = 0;
    }

    public Cell AddCell(string value)
    {
        Cell cell = new Cell(value);

        return AddCell(cell);
    }

    public Cell AddCell(Cell cell)
    {
        if (CellsCount == _cell.Length)
        {
            Array.Resize(ref _cell, _cell.Length + ChangeCapacityStep);
        }

        _cell[CellsCount] = cell;

        _cell[CellsCount].Indent = Indent + IndentCell;

        CellsCount++;

        return _cell[CellsCount - 1];
    }
}