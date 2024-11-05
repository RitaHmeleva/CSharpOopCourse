namespace ArrayListHome;

internal class ArrayListHomeMain
{
    public static List<string> GetFileLinesList(string fileName)
    {
        List<string> linesList = new List<string>();

        using StreamReader reader = new StreamReader(fileName);

        string? currentLine;

        while ((currentLine = reader.ReadLine()) != null)
        {
            linesList.Add(currentLine);
        }

        return linesList;
    }

    public static void RemoveEvenNumbers(List<int> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<T> GetUniqueElements<T>(List<T> list)
    {
        List<T> uniqueList = new List<T>(list.Count);

        for (int i = 0; i < list.Count; i++)
        {
            if (!uniqueList.Contains(list[i]))
            {
                uniqueList.Add(list[i]);
            }
        }

        return uniqueList;
    }

    static void Main(string[] args)
    {
        List<string>? linesList = null;

        try
        {
            linesList = GetFileLinesList("..\\..\\list.txt");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        foreach (string line in linesList!)
        {
            Console.WriteLine(line);
        }

        Console.WriteLine();

        List<int> numbersList = new List<int>() { 2, 5, 3, 10, 5, 3, 5, 9, 20 };

        RemoveEvenNumbers(numbersList);

        foreach (int number in numbersList)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();

        List<int> distinctList = GetUniqueElements(numbersList);

        foreach (int element in distinctList)
        {
            Console.WriteLine(element);
        }

        Console.ReadLine();
    }
}