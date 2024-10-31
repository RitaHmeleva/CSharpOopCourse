namespace ArrayListHome;

internal class ArrayListHomeMain
{
    public static List<string> ReadFileToList(string fileName)
    {
        List<string> stringsList = new List<string>();

        try
        {
            using StreamReader reader = new StreamReader(fileName);

            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                stringsList.Add(currentLine);
            }
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

        return stringsList;
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

    public static  List<T> RemoveRepeatedElements<T>(List<T> list)
    {
        List<T> newList = new List<T>(list.Count);

        if (list.Count == 0)
        {
            return newList;
        }

        newList.Add(list[0]);

        for (int i = 1; i < list.Count; i++)
        {
            if (!newList.Contains(list[i]))
            {
                newList.Add(list[i]);
            }
        }

        return newList;
    }

    static void Main(string[] args)
    {
        List<string> stringsList = ReadFileToList("..\\..\\list.txt");

        foreach (string line in stringsList)
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

        List<int> distinctList = RemoveRepeatedElements<int>(numbersList);

        foreach (int element in distinctList)
        {
            Console.WriteLine(element);
        }

        Console.ReadLine();
    }
}