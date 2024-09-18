namespace GraphTask;

public class Graph
{
    bool[] visited;
    int[,] graph;

    public Graph(int[,] graph)
    {
        this.graph = new int[graph.GetLength(1), graph.GetLength(0)];

        Array.Copy(graph, this.graph, graph.Length);
    }

    public void WidthTraversal()
    {
        visited = new bool[graph.GetLength(0)];

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(0);

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (queue.Count == 0)
            {
                queue.Enqueue(i);
            }

            int node = queue.Dequeue();
            visited[node] = true;

            for (int j = 0; j < graph.GetLength(0); j++)
            {
                if (graph[node, j] == 1 && visited[j] == false)
                {
                    queue.Enqueue(j);
                    visited[j] = true;
                }
            }
        }
    }

    public void DepthTraversal()
    {
        visited = new bool[graph.GetLength(0)];

        Stack<int> stack = new Stack<int>();

        stack.Push(0);

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(i);
            }

            int node = stack.Pop();
            visited[node] = true;

            for (int j = graph.GetLength(0) - 1; j >= 0; j--)
            {
                if (graph[node, j] == 1 && visited[j] == false)
                {
                    stack.Push(j);
                    visited[j] = true;
                }
            }
        }
    }
}