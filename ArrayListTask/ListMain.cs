namespace ArrayListMain;

internal class ListMain
{
    static void Main(string[] args)
    {
        ArrayListTask.List<int> list1 = new ArrayListTask.List<int>();

        list1.Add(8);
        list1.Add(7);
        list1.Add(1);
        list1.Add(2);
        list1.Add(3);
        list1.Add(4);

        list1.TrimExcess();

        Console.WriteLine(list1);

        Console.ReadLine();
    }
}