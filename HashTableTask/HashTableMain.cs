namespace HashTableTask;

internal class HashTableMain
{
    static void Main(string[] args)
    {
        HashTable<int> hashTable = new HashTable<int>();

        hashTable.Add(5);
        hashTable.Add(6);
        hashTable.Add(7);
        hashTable.Add(1);
        hashTable.Add(-6);
        hashTable.Add(77);


        Console.WriteLine(hashTable);
        Console.WriteLine($"Count = {hashTable.Count}");
        Console.WriteLine(hashTable.Contains(6));


        hashTable.Remove(6);
        Console.WriteLine(hashTable.Contains(6));

        int[] array = new int[10];

        hashTable.CopyTo(array, 0);

        Console.WriteLine();

        foreach (int number in array)
        {
            Console.WriteLine(number);
        }

        try
        {
            hashTable.CopyTo(array, 7);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        foreach (int number in array)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();

        hashTable.Clear();
        Console.WriteLine($"Count = {hashTable.Count}");

        foreach (int item in hashTable)
        {
            Console.WriteLine(item);
        }


        Console.ReadLine();
    }
}