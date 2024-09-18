namespace TreeTask;

internal class TreeMain
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();

        tree.InsertRoot(12);
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

        Console.WriteLine(tree.ToString());

        tree.DeleteNode(5);
        Console.WriteLine("Дерево: ");
        Console.WriteLine(tree.ToString());

        Console.WriteLine("Обход в глубину с рекурсией: ");
        tree.ReversalDepthTraversal(tree.root);

        Console.WriteLine("Обход в ширину: ");
        tree.WidthTraversal();

        Console.WriteLine("Обход в глубину: ");
        tree.DepthTraversal();

        Console.WriteLine("Число элементов: " + tree.GetCount());

        Console.ReadLine();
    }
}