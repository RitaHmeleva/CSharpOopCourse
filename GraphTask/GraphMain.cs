namespace GraphTask;

internal class GraphMain
{
    public static void PrintNode(int node)
    {
        Console.WriteLine(node);
    }

    static void Main(string[] args)
    {
        int[,] matrix =
        {
            { 0, 1, 1, 1, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0 }
        };

        Graph graph = new Graph(matrix);

        Console.WriteLine("Visit nodes:");
        Console.WriteLine("Обход в ширину:");
        graph.BreadthTraversal(PrintNode);

        Console.WriteLine("Обход в глубину:");
        graph.DepthTraversal(PrintNode);

        Console.WriteLine("Рекурсивный обход в глубину:");
        graph.DepthTraversalRecursive(PrintNode);

        Console.ReadLine();
    }
}