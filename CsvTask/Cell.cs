using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask;

internal class Cell
{
    private readonly string NewLine = Environment.NewLine;

    private string IndentString => new String(' ', Indent);

    public string Value { get; set; }

    public int Indent { get; set; } = 4;

    private string _cell;

    public string Html => $"{IndentString}<td>{Value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(NewLine, "<br/>")}</td>";

    public Cell(string value)
    {
        Value = value;
    }
}