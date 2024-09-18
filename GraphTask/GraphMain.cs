namespace GraphTask;

internal class GraphMain
{
    static void Main(string[] args)
    {
        int[,] arrayGraph =
    {
        { 0, 1, 1, 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 1, 1, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 0, 0, 1, 0, 0 },
        { 0, 0, 1, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 1, 0 }
    };

        Graph graph = new Graph(arrayGraph);
        
        graph.WidthTraversal();

        graph.DepthTraversal();

        Console.ReadLine();
    }
}