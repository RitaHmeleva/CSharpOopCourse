namespace GraphTask;

internal class GraphMain
{
    static void PrintNode(int node)
    {
        Console.WriteLine(node);
    }

    static void Main(string[] args)
    {
        int[,] array =
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

        Graph matrix = new Graph(array);

        Console.WriteLine("Visit nodes:");
        Console.WriteLine("Обход в ширину:");
        matrix.WidthTraversal(PrintNode);

        Console.WriteLine("Обход в глубину:");
        matrix.DepthTraversal(PrintNode);

        Console.WriteLine("Рекурсивный обход в глубину:");
        matrix.RecursionDepthTraversal(PrintNode);

        Console.ReadLine();
    }
}