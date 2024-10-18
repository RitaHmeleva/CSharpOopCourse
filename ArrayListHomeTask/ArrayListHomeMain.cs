namespace ArrayListHome;

internal class ArrayListHomeMain
{
    static void Main(string[] args)
    {
        ArrayListHome<string> list = new ArrayListHome<string>();

        list.ReadFileToList("..\\..\\list.txt");

        Console.WriteLine(list);

        list.RemoveEvenNumbers();

        Console.WriteLine(list);

        list.RemoveRepeated();

        Console.WriteLine(list);

        Console.ReadLine();
    }
}