using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask;

internal class Table
{
    private const int DefaultCapacity = 10;
    private const int ChangeCapacityStep = 10;

    private readonly string NewLine = Environment.NewLine;

    private Row[] _row;

    public int RowsCount { get; set; }

    private string IndentString => new String(' ', Indent);

    public int Indent { get; set; } = 0;

    public int IndentRow { get; set; } = 2;

    public string Html => $"{IndentString}<table>{NewLine}{string.Join(NewLine, _row.Take(RowsCount).Select(r => r.Html))}{NewLine}{IndentString}</table>";

    public Table() : this(DefaultCapacity) { }

    public Table(int capacity)
    {
        _row = new Row[capacity];
        RowsCount = 0;
    }

    public Row AddRow()
    {
        if (RowsCount == _row.Length)
        {
            Array.Resize(ref _row, _row.Length + ChangeCapacityStep);
        }

        _row[RowsCount] = new Row();

        _row[RowsCount].Indent = Indent + IndentRow;

        RowsCount++;

        return _row[RowsCount - 1];
    }
}