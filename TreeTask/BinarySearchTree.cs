using System.Text;

namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;
    private readonly Comparer<T> _comparer;

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(Comparer<T> comparer)
    {
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public int Count { get; private set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        BreadthTraversal(data =>
        {
            stringBuilder
                .Append(' ')
                .Append(data)
                .Append(':');

            TreeNode<T> node = GetNode(data)!;

            if (node.Left != null)
            {
                stringBuilder.Append(node.Left.Data);
            }

            stringBuilder.Append(',');

            if (node.Right != null)
            {
                stringBuilder.Append(node.Right.Data);
            }

            stringBuilder.Append(';');
        });

        return stringBuilder.ToString();
    }

    private TreeNode<T>? GetNode(T data)
    {
        TreeNode<T>? node = _root;

        while (node != null)
        {
            int comparisonResult = _comparer.Compare(data, node.Data);

            if (comparisonResult == 0)
            {
                return node;
            }

            if (comparisonResult < 0)
            {
                node = node.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        return null;
    }


    public void Add(T data)
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
            int comparisonResult = _comparer.Compare(data, currentNode.Data);

            if (comparisonResult < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = node;
                    Count++;

                    return;
                }

                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = node;
                    Count++;

                    return;
                }

                currentNode = currentNode.Right;
            }
        }
    }

    private void ReplaceNode(TreeNode<T>? deletedNodeParent, TreeNode<T>? deletedNode, TreeNode<T>? replacedNode)
    {
        if (deletedNodeParent is null)
        {
            _root = replacedNode;
        }
        else
        {
            if (deletedNodeParent.Left == deletedNode)
            {
                deletedNodeParent.Left = replacedNode;
            }
            else
            {
                deletedNodeParent.Right = replacedNode;
            }
        }
    }

    public bool Remove(T data)
    {
        if (_root == null)
        {
            return false;
        }

        TreeNode<T>? parentNode = null;
        TreeNode<T>? node = _root;

        while (node != null)
        {
            int comparisonResult = _comparer.Compare(data, node.Data);

            if (comparisonResult == 0)
            {
                if (node.Left == null || node.Right == null)
                {
                    ReplaceNode(parentNode, node, node.Left ?? node.Right);

                    return true;
                }

                TreeNode<T>? minNodeParent = node;
                TreeNode<T> minNode = node.Right;

                while (minNode.Left != null)
                {
                    minNodeParent = minNode;
                    minNode = minNode.Left;
                }

                if (minNodeParent != node)
                {
                    minNodeParent.Left = minNode.Right;
                    minNode.Right = node.Right;
                }

                minNode.Left = node.Left;
                ReplaceNode(parentNode, node, minNode);

                return true;
            }

            parentNode = node;

            if (comparisonResult < 0)
            {
                node = node.Left;
            }
            else
            {
                node = node.Right;
            }
        }

        return false;
    }

    public void BreadthTraversal(Action<T> action)
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

    private static void DepthTraversalRecursive(TreeNode<T> node, Action<T> action)
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