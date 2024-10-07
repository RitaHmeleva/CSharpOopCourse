namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? root;
    private int count;
    private Comparer<T>? comparer;

    public BinarySearchTree()
    {
        root = null;
        comparer = null;
    }

    public BinarySearchTree(Comparer<T> comparer)
    {
        root = null;
        this.comparer = comparer;
    }

    public int Count { get; private set; }

    private string GetString(TreeNode<T> node)
    {
        string nodeString = "";

        if (node != null)
        {
            nodeString += node.Data + ":(";

            if (node.Left != null)
            {
                nodeString += GetString(node.Left);
            }

            nodeString += ", ";

            if (node.Right != null)
            {
                nodeString += GetString(node.Right);
            }

            nodeString += ")";
        }

        return nodeString;
    }

    public override string ToString()
    {
        string tree = "(";

        if (root != null)
        {
            tree += GetString(root);
        }

        tree += ")";

        return tree;
    }

    public int CompareData(T data1, T data2)
    {
        if (comparer != null)
        {
            return comparer.Compare(data1, data2);
        }

        return Comparer<T>.Default.Compare(data1, data2);
    }

    public void InsertRoot(T data)
    {
        root = new TreeNode<T>(data);
        count++;
    }

    public void InsertNode(T data)
    {
        InsertNode(new TreeNode<T>(data));
    }

    private void InsertNode(TreeNode<T> node)
    {
        if (root == null)
        {
            root = node;
            count++;
        }
        else
        {
            TreeNode<T> currentNode = root;

            do
            {
                int comparisonResult = CompareData(node.Data, currentNode.Data);

                if (comparisonResult == 0)
                {
                    break;
                }
                else if (comparisonResult < 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = node;
                        count++;
                        break;
                    }
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = node;
                        count++;
                        break;
                    }
                    currentNode = currentNode.Right;
                }
            }
            while (currentNode != null);
        }
    }

    public bool DeleteNode(T data)
    {
        if (root == null)
        {
            return false;
        }
        else
        {
            TreeNode<T>? parentNode = null;
            TreeNode<T>? node = root;

            do
            {
                int comparisonResult = CompareData(data, node.Data);

                if (comparisonResult == 0)
                {
                    if (node.Left == null && node.Right == null)
                    {
                        if (parentNode == null)
                        {
                            root = null;
                        }
                        else
                        {
                            if (parentNode.Left == node)
                            {
                                parentNode.Left = null;
                            }
                            else
                            {
                                parentNode.Right = null;
                            }
                        }

                        return true;
                    }

                    if (node.Left == null)
                    {
                        if (parentNode == null)
                        {
                            root = node.Right;
                        }
                        else
                        {
                            if (parentNode.Left == node)
                            {
                                parentNode.Left = node.Right;
                            }
                            else
                            {
                                parentNode.Right = node.Right;
                            }
                        }

                        return true;
                    }

                    if (node.Right == null)
                    {
                        if (parentNode == null)
                        {
                            root = node.Left;
                        }
                        else
                        {
                            if (parentNode.Left == node)
                            {
                                parentNode.Left = node.Left;
                            }
                            else
                            {
                                parentNode.Right = node.Left;
                            }
                        }

                        return true;
                    }

                    TreeNode<T> minNodeParent = node.Right;
                    TreeNode<T> minNode = minNodeParent;

                    while (minNode.Left != null)
                    {
                        minNodeParent = minNode;
                        minNode = minNode.Left;
                    }

                    if (minNode.Right != null)
                    {
                        minNodeParent.Left = minNode.Right;

                    }
                    else
                    {
                        minNodeParent.Left = null;
                    }

                    minNode.Right = node.Right;
                    minNode.Left = node.Left;

                    if (parentNode == null)
                    {
                        root = minNode; ;
                    }
                    else
                    {
                        if (parentNode.Left == node)
                        {
                            parentNode.Left = minNode;
                        }
                        else
                        {
                            parentNode.Right = minNode;
                        }
                    }

                    return true;

                }
                else if (comparisonResult < 0)
                {
                    parentNode = node;
                    node = node.Left;
                }
                else
                {
                    parentNode = node;
                    node = node.Right;
                }

            } while (node != null);

            return false;
        }
    }

    public void WidthTraversal(Action<T> action)
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        if (root != null)
        {
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();

                action.Invoke(current.Data);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }
    }

    public void DepthTraversal(Action<T> action)
    {
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

        if (root != null)
        {
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> current = stack.Pop();

                action.Invoke(current.Data);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }
    }

    public void RecursionDepthTraversal(Action<T> action)
    {
        if (root != null)
        {
            RecursionDepthTraversal(root, action);
        }
    }

    private void RecursionDepthTraversal(TreeNode<T> node, Action<T> action)
    {
        action.Invoke(node.Data);

        if (node.Left != null)
        {
            RecursionDepthTraversal(node.Left, action);
        }

        if (node.Right != null)
        {
            RecursionDepthTraversal(node.Right, action);
        }
    }
}