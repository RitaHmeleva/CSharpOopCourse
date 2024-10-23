namespace CsvTask;

internal class CsvMain
{
    static void Main(string[] args)
    {
        try
        {
            Csv csv = new Csv();

            csv.ReadCsvToHtml("..\\..\\input.csv", "..\\..\\output.html");

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