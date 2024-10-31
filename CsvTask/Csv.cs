using System.Text;

namespace CsvTask;

class Csv
{
    public void ConvertCsvToHtml(string fileName, string outputTableName)
    {
        bool isQuotedString = false;
        bool isNewString;
        int characterIndex;

        int rowsCount = 0;

        StringBuilder line = new StringBuilder();

        using StreamWriter writer = new StreamWriter(outputTableName);

        writer.WriteLine("<!DOCTYPE html>");
        writer.WriteLine("<html>");
        writer.WriteLine("<head>");
        writer.WriteLine("<title>CsvParser</title>");
        writer.WriteLine("<meta charSet = \"utf -8\" />");
        writer.WriteLine("<style>");
        writer.WriteLine("table, th, td {");
        writer.WriteLine("border: 1px solid black;");
        writer.WriteLine("border-collapse: collapse;");
        writer.WriteLine("}");
        writer.WriteLine("</style>");
        writer.WriteLine("</head>");
        writer.WriteLine("<body>");

        using StreamReader reader = new StreamReader(fileName);

        string? currentLine;

        writer.WriteLine("<table>");

        while ((currentLine = reader.ReadLine()) != null)
        {
            if (isQuotedString)
            {
                line.Append("<br/>");
            }
            else
            {
                if (rowsCount > 0)
                {
                    writer.WriteLine("</tr>");
                }

                writer.WriteLine("<tr>");

                if (rowsCount > 0)
                {
                    if (line.Length > 0)
                    {
                        writer.Write("<td>");
                        writer.Write(line.ToString());
                        writer.WriteLine("</td>");

                        line.Clear();
                    }
                }

                rowsCount++;
            }

            isNewString = !isQuotedString;

            characterIndex = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (isNewString)
                {
                    isQuotedString = currentLine[i] == '"';

                    if (isQuotedString)
                    {
                        isNewString = false;

                        continue;
                    }
                }

                if (currentLine[i] == '"')
                {
                    if (isQuotedString)
                    {
                        if (i < currentLine.Length - 1 && currentLine[i + 1] == '"')
                        {
                            line.Append('"');
                            characterIndex += 2;
                            i++;

                            continue;
                        }

                        isQuotedString = false;

                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (currentLine[i] == ',' && !isQuotedString)
                {
                    writer.Write("<td>");
                    writer.Write(line.ToString());
                    writer.WriteLine("</td>");

                    line.Clear();
                    isNewString = true;

                    continue;
                }

                if (currentLine[i] == '<')
                {
                    line.Append("&lt");
                }

                if (currentLine[i] == '>')
                {
                    line.Append("&gt");
                }

                if (currentLine[i] == '<')
                {
                    line.Append("&amp");
                }

                line.Append(currentLine[i]);

                isNewString = false;
            }

            if (!isQuotedString)
            {
                writer.Write("<td>");
                writer.Write(line.ToString());
                writer.WriteLine("</td>");

                line.Clear();
                isNewString = true;
            }
        }

        if (line.Length > 0)
        {
            writer.Write("<td>");
            writer.Write(line.ToString());
            writer.WriteLine("</td>");
            writer.WriteLine("</tr>");
        }

        writer.WriteLine("</table>");
        writer.WriteLine("</body>");
        writer.Write("</html>");
    }
}