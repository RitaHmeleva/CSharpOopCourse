using System.Text;

namespace ArrayListHome;

internal class ArrayListHomeMain
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();

        void ReadFileToList(string fileName, List<string> list)
        {
            try
            {
                using StreamReader reader = new StreamReader(fileName);

                string? currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(currentLine);
                }
            }
            catch (FileNotFoundException fileNotFoundExeption)
            {
                Console.WriteLine(fileNotFoundExeption.Message);
            }
            catch (IOException ioExeption)
            {
                Console.WriteLine(ioExeption.Message);
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }

        void RemoveEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        void RemoveRepeated(List<int> list)
        {
            List<int> newList = new List<int>();

            newList.Add(list[0]);

            for (int i = 1; i < list.Count; i++)
            {
                if (!newList.Contains(list[i]))
                {
                    newList.Add(list[i]);
                }
            }

            list.Clear();
            list.AddRange(newList);
        }

        ReadFileToList("..\\..\\list.txt", list);

        foreach (string item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        List<int> numbersList = new List<int>() { 2, 5, 3, 10, 5, 3, 5, 9, 20 };

        RemoveEvenNumbers(numbersList);

        foreach (int item in numbersList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        RemoveRepeated(numbersList);

        foreach (int item in numbersList)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}