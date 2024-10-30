namespace GraphTask;

public class Graph
{
    private readonly int[,] _matrix;

    public Graph(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException($"Rows count {matrix.GetLength(0)} should be = columns count {matrix.GetLength(1)}", nameof(matrix));
        }

        _matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

        Array.Copy(matrix, _matrix, matrix.Length);
    }

    public void BreadthTraversal(Action<int> action)
    {
        bool[] visited = new bool[_matrix.GetLength(0)];

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                if (visited[vertex])
                {
                    continue;
                }

                visited[vertex] = true;
                action(vertex);

                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (_matrix[vertex, j] != 0 && !visited[j])
                    {
                        queue.Enqueue(j);
                    }
                }
            }
        }
    }

    public void DepthTraversal(Action<int> action)
    {
        bool[] visited = new bool[_matrix.GetLength(0)];

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            stack.Push(i);

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (visited[vertex])
                {
                    continue;
                }

                visited[vertex] = true;
                action(vertex);

                for (int j = _matrix.GetLength(0) - 1; j >= 0; j--)
                {
                    if (_matrix[vertex, j] != 0 && !visited[j])
                    {
                        stack.Push(j);
                    }
                }
            }
        }
    }

    public void DepthTraversalRecursive(Action<int> action)
    {
        bool[] visited = new bool[_matrix.GetLength(0)];

        for (int i = 0; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                DepthTraversalRecursive(i, visited, action);
            }
        }
    }

    private void DepthTraversalRecursive(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;
        action(vertex);

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (_matrix[vertex, i] != 0 && !visited[i])
            {
                DepthTraversalRecursive(i, visited, action);
            }
        }
    }
}