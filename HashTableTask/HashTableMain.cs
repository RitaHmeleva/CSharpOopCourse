﻿namespace HashTableTask;

internal class HashTableMain
{
    static void Main(string[] args)
    {
        HashTable<int> hashTable = new HashTable<int>() { 5, 6, 7, 1, -6, 77 };

        Console.WriteLine(hashTable);
        Console.WriteLine($"Count = {hashTable.Count}");
        Console.WriteLine(hashTable.Contains(6));

        hashTable.Remove(66);
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
            hashTable.CopyTo(array, 2);
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

        foreach (int item in hashTable)
        {
            Console.WriteLine(item);
        }

        hashTable.Clear();
        Console.WriteLine($"Count = {hashTable.Count}");

        Console.ReadLine();
    }
}