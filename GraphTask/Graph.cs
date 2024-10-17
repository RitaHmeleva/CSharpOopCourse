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
        bool[] visited = new bool[_graph.GetLength(0)];

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int vertex = queue.Dequeue();

                    if (!visited[vertex])
                    {
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
            }
        }
    }

    public void DepthTraversal(Action<int> action)
    {
        bool[] visited = new bool[_graph.GetLength(0)];

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (!visited[vertex])
                {
                    visited[vertex] = true;
                    action(vertex);

                    for (int j = _graph.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (_graph[vertex, j] != 0 && !(visited[j]))
                        {
                            stack.Push(j);
                        }
                    }
                }
            }
        }
    }

    public void RecursionDepthTraversal(Action<int> action)
    {
        bool[] visited = new bool[_graph.GetLength(0)];

        for (int i = 0; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                RecursionDepthTraversal(i, visited, action);
            }
        }
    }

    public void RecursionDepthTraversal(int i, bool[] visited, Action<int> action)
    {
        visited[i] = true;
        action(i);

        for (int j = 0; j < _graph.GetLength(0); j++)
        {
            if (_graph[i, j] != 0 && !(visited[j]))
            {
                RecursionDepthTraversal(j, visited, action);
            }
        }
    }
}