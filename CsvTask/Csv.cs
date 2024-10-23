using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask;

class Csv
{
    private Table _table;

    public char Separator { get; set; } = ',';

    public Csv()
    {
        _table = new Table();
    }

    public void ReadCsvToHtml(string fileName, string outputTableName)
    {
        bool isQuotedString = false;
        bool isNewString;
        int characterIndex;

        Row row = null;

        StringBuilder line = new StringBuilder();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (isQuotedString)
                {
                    line.AppendLine();
                }
                else
                {
                    row = _table.AddRow();

                    if (_table.RowsCount > 1)
                    {
                        if (line.Length > 0)
                        {
                            row.AddCell(line.ToString());
                            line.Clear();
                        }
                    }
                }

                isNewString = !isQuotedString;

                characterIndex = 0;

                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (isNewString)
                    {
                        isQuotedString = currentLine[j] == '"';

                        if (isQuotedString)
                        {
                            isNewString = false;
                            j++;

                            continue;
                        }
                    }

                    if (currentLine[j] == '"')
                    {
                        if (isQuotedString)
                        {
                            if (j < currentLine.Length - 1 && currentLine[j + 1] == '"')
                            {
                                line.Append('"');
                                characterIndex += 2;
                                continue;
                            }

                            isQuotedString = false;
                            j++;

                            continue;
                        }
                        else
                        {
                            j++;

                            continue;
                        }
                    }

                    if (currentLine[j] == ',' && !isQuotedString)
                    {
                        row.AddCell(line.ToString());
                        line.Clear();
                        isNewString = true;
                        j++;

                        continue;
                    }

                    line.Append(currentLine[j]);

                    isNewString = false;
                }

                if (!isQuotedString)
                {
                    row.AddCell(line.ToString());
                    line.Clear();
                    isNewString = true;
                }
            }

            if (line.Length > 0)
            {
                row.AddCell(line.ToString());
            }
        }

        using (StreamWriter writer = new StreamWriter(outputTableName))
        {
            writer.WriteLine(_table.Html);
        }
    }
}