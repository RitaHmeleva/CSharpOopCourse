namespace TreeTask;

internal class TreeMain
{
    static void PrintData(int data)
    {
        Console.WriteLine(data);
    }

    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.InsertNode(12);
        tree.InsertNode(3);
        tree.InsertNode(14);
        tree.InsertNode(1);
        tree.InsertNode(5);
        tree.InsertNode(13);
        tree.InsertNode(16);
        tree.InsertNode(4);
        tree.InsertNode(9);
        tree.InsertNode(15);
        tree.InsertNode(7);
        tree.InsertNode(10);
        tree.InsertNode(6);
        tree.InsertNode(8);
        tree.InsertNode(11);

        Console.WriteLine(tree);

        tree.DeleteNode(12);
        Console.WriteLine("Дерево:");
        Console.WriteLine(tree);

        Console.WriteLine("Обход в глубину с рекурсией:");

        tree.DepthTraversalRecursive(PrintData);

        Console.WriteLine("Обход в глубину:");
        tree.DepthTraversal(PrintData);

        Console.WriteLine("Обход в ширину:");
        tree.BreadthFirstSearch(PrintData);

        Console.WriteLine("Число элементов: " + tree.Count);

        Console.ReadLine();
    }
}