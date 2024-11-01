namespace TreeTask;

internal class TreeMain
{
    public static void PrintData<T>(T data)
    {
        Console.WriteLine(data);
    }

    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Add(12);
        tree.Add(3);
        tree.Add(15);
        tree.Add(14);
        tree.Add(5);
        tree.Add(1);
        tree.Add(9);
        tree.Add(13);
        tree.Add(4);
        tree.Add(10);
        tree.Add(11);
        tree.Add(16);

        Console.WriteLine(tree);

        tree.Remove(5);
        Console.WriteLine("Дерево:");
        Console.WriteLine(tree);

        Console.WriteLine("Обход в глубину с рекурсией:");

        tree.DepthTraversalRecursive(PrintData);

        Console.WriteLine("Обход в глубину:");
        tree.DepthTraversal(PrintData);

        Console.WriteLine("Обход в ширину:");
        tree.BreadthTraversal(PrintData);

        Console.WriteLine("Число элементов: " + tree.Count);

        Console.ReadLine();
    }
}