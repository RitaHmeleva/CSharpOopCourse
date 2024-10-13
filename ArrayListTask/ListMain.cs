using System.Collections.Generic;
using System.ComponentModel;

namespace ArrayListTask;

internal class ListMain
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>() { 8, 7, 1, 2, 3, 4 };
        Console.WriteLine(list);
        list.TrimExcess();

        Console.WriteLine(list);

        list.RemoveAt(2);
        list.TrimExcess();

        Console.WriteLine(list);

        Console.WriteLine(list.IndexOf(1));

        list.Insert(3, 2);
        Console.WriteLine(list);

        Console.WriteLine(list.Contains(5));

        int[] array = new int[10];

        list.CopyTo(array, 1);

        foreach (int number in array)
        {
            Console.WriteLine(number);
        }

        list.Remove(8);
        Console.WriteLine(list);

        list.Clear();
        Console.WriteLine(list.Count);

        Console.ReadLine();
    }
}