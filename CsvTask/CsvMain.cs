namespace CsvTask;

internal class CsvMain
{
    static void Main(string[] args)
    {
        try
        {
            string csvFileName = string.Empty;
            string htmlFileName = string.Empty;

            int i = 0;
            while (i < args.Length)
            {
                if (args[i] == "-help")
                {
                    Console.WriteLine("Usage: CsvParser.exe -i \"input csv file\" -o \"output html file\"");
                    return;
                }

                if (args[i] == "-i")
                {
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Missing input file name!");
                        break;
                    }

                    csvFileName = args[i + 1];

                    i += 2;
                }

                if (args[i] == "-o")
                {
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Missing output file name!");
                        break;
                    }

                    htmlFileName = args[i + 1];

                    i += 2;
                }
            }



            Csv csv = new Csv();

            csv.ConvertCsvToHtml(csvFileName, htmlFileName);

            Console.WriteLine("Done!");
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            Console.WriteLine(fileNotFoundException.Message);
        }
        catch (IOException ioException)
        {
            Console.WriteLine(ioException.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}