using System.Text;
using System.Xml.Linq;

namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;
    private Comparer<T> _comparer;

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(Comparer<T> comparer)
    {
        this._comparer = comparer;
    }

    public int Count { get; private set; }

    private static string GetString(TreeNode<T> node)
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (node == null)
        {
            return stringBuilder.ToString();
        }

        stringBuilder.Append(node.Data);
        stringBuilder.Append(":(");

        if (node.Left != null)
        {
            stringBuilder.Append(GetString(node.Left));
        }

        stringBuilder.Append(", ");

        if (node.Right != null)
        {
            stringBuilder.Append(GetString(node.Right));
        }

        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('(');

        if (_root != null)
        {
            stringBuilder.Append(GetString(_root));
        }

        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public int CompareData(T data1, T data2)
    {
        return _comparer.Compare(data1, data2);
    }

    public void InsertNode(T data)
    {
        TreeNode<T> node = new TreeNode<T>(data);

        if (_root == null)
        {
            _root = node;
            Count++;

            return;
        }

        TreeNode<T> currentNode = _root;

        while (currentNode != null)
        {
            int comparisonResult = CompareData(node.Data, currentNode.Data);

            if (comparisonResult < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = node;
                    Count++;
                    break;
                }

                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = node;
                    Count++;
                    break;
                }

                currentNode = currentNode.Right;
            }
        }
    }

    private void MoveNode(TreeNode<T>? deletedParentNode, TreeNode<T>? deletedNode, TreeNode<T>? movedNode)
    {
        if (deletedParentNode is null)
        {
            _root = movedNode;
        }
        else
        {
            if (deletedParentNode.Left == deletedNode)
            {
                deletedParentNode.Left = movedNode;
            }
            else
            {
                deletedParentNode.Right = movedNode;
            }
        }

        Count--;
    }

    public bool DeleteNode(T data)
    {
        if (_root == null)
        {
            return false;
        }

        TreeNode<T>? parentNode = null;
        TreeNode<T>? node = _root;

        while (node != null)
        {
            int comparisonResult = CompareData(data, node.Data);

            if (comparisonResult == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    MoveNode(parentNode, node, null);

                    return true;
                }

                if (node.Left == null)
                {
                    MoveNode(parentNode, node, node.Right);

                    return true;
                }

                if (node.Right == null)
                {
                    MoveNode(parentNode, node, node.Left);

                    return true;
                }

                TreeNode<T>? minNodeParent = null;
                TreeNode<T> minNode = node.Right;

                while (minNode.Left != null)
                {
                    minNodeParent = minNode;
                    minNode = minNode.Left;
                }

                if (minNodeParent is not null)
                {
                    minNodeParent.Left = minNode.Right;
                    minNode.Right = node.Right;
                    minNode.Left = node.Left;
                }

                MoveNode(parentNode, node, minNode);

                return true;
            }

            if (comparisonResult < 0)
            {
                parentNode = node;
                node = node.Left;
            }
            else
            {
                parentNode = node;
                node = node.Right;
            }

        };

        return false;
    }

    public void BreadthFirstSearch(Action<T> action)
    {
        if (_root == null)
        {
            return;
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode<T> currentNode = queue.Dequeue();

            action(currentNode.Data);

            if (currentNode.Left != null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode.Right != null)
            {
                queue.Enqueue(currentNode.Right);
            }
        }
    }

    public void DepthTraversal(Action<T> action)
    {
        if (_root == null)
        {
            return;
        }

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode<T> currentNode = stack.Pop();

            action(currentNode.Data);

            if (currentNode.Right != null)
            {
                stack.Push(currentNode.Right);
            }

            if (currentNode.Left != null)
            {
                stack.Push(currentNode.Left);
            }
        }
    }

    public void DepthTraversalRecursive(Action<T> action)
    {
        if (_root != null)
        {
            DepthTraversalRecursive(_root, action);
        }
    }

    private void DepthTraversalRecursive(TreeNode<T> node, Action<T> action)
    {
        action(node.Data);

        if (node.Left != null)
        {
            DepthTraversalRecursive(node.Left, action);
        }

        if (node.Right != null)
        {
            DepthTraversalRecursive(node.Right, action);
        }
    }
}