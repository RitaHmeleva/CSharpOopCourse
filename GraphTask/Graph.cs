namespace GraphTask;

public class Graph
{
    private int[,] _graph;

    public Graph(int[,] graph)
    {
        if (graph.GetLength(0) != graph.GetLength(1))
        {
            throw new Exception($"Rows count {graph.GetLength(0)} should be = columns count {graph.GetLength(1)}");
        }

        this._graph = new int[graph.GetLength(0), graph.GetLength(1)];

        Array.Copy(graph, this._graph, graph.Length);
    }

    public void WidthTraversal(Action<int> action)
    {
        bool[] visited;

        visited = new bool[_graph.GetLength(0)];

        Queue<int> queue = new Queue<int>();

        //queue.Enqueue(0);

        for (int i = 0; i < _graph.GetLength(0); i++)
        {
            if (queue.Count == 0)
            {
                queue.Enqueue(i);
            }

            int vertex = queue.Dequeue();
            visited[vertex] = true;
            action(vertex);

            for (int j = 0; j < _graph.GetLength(0); j++)
            {
                if (_graph[vertex, j] != 0 && !(visited[j]))
                {
                    queue.Enqueue(j);
                    visited[j] = true;
                    action(j);
                }
            }
        }
    }

    public void DepthTraversal(Action<int> action)
    {
        bool[] visited;

        visited = new bool[_graph.GetLength(0)];

        Stack<int> stack = new Stack<int>();

        stack.Push(0);

        for (int i = 0; i < _graph.GetLength(0); i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(i);
            }

            int vertex = stack.Pop();
            visited[vertex] = true;
            action(vertex);

            for (int j = _graph.GetLength(0) - 1; j >= 0; j--)
            {
                if (_graph[vertex, j] != 0 && !(visited[j]))
                {
                    stack.Push(j);
                    visited[j] = true;
                    action(j);
                }
            }
        }
    }
}