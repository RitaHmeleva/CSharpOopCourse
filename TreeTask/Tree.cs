using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreeTask;

public class TreeNode<T>
{
    public TreeNode<T> Left { get; set; }

    public TreeNode<T> Right { get; set; }

    public T Data { get; set; }

    public TreeNode(T data)
    {
        Data = data;
    }
    public override string ToString()
    {
        string s = "";

        s += Data.ToString() + ":(";
        if (Left != null)
        {
            s += Left.ToString();
        }
        s += ", ";
        if (Right != null)
        {
            s += Right.ToString();
        }
        s += ")";

        return s;
    }
}

public class BinaryTree<T>
{
    public TreeNode<T> root;
    private int count;

    public BinaryTree()
    {
        root = null;
    }

    public override string ToString()
    {
        return root.ToString();
    }

    public void InsertRoot(T data)
    {
        root = new TreeNode<T>(data);
        count++;
    }

    public void InsertNode(T data)
    {
        InsertNode(root, new TreeNode<T>(data));
        count++;
    }

    public void InsertNode(TreeNode<T> currentNode, TreeNode<T> node)
    {
        int comparison = Comparer<T>.Default.Compare(node.Data, currentNode.Data);


        if (comparison < 0)
        {
            if (currentNode.Left != null)
            {
                InsertNode(currentNode.Left, node);
            }
            else
            {
                currentNode.Left = node;
            }
        }
        else
        {
            if (currentNode.Right != null)
            {
                InsertNode(currentNode.Right, node);
            }
            else
            {
                currentNode.Right = node;
            }
        }
    }

    public void DeleteNode(T data)
    {
        if (root == null)
        {

        }

        DeleteNode(root, data);
    }

    public TreeNode<T> DeleteNode(TreeNode<T> node, T data)
    {
        if (node.Data.Equals(data))
        {
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            if (node.Right == null)
            {
                return node.Left;
            }

            TreeNode<T> minimumNodeParent = node.Right;
            TreeNode<T> minimumNode = node.Right.Left;

            while (minimumNode.Left != null)
            {
                minimumNodeParent = minimumNode;
                minimumNode = minimumNode.Left;
            }

            if (minimumNode.Right != null)
            {
                minimumNodeParent.Left = minimumNode.Right;

            }
            else
            {
                minimumNodeParent.Left = null;
            }
            
            minimumNode.Right = node.Right;
            minimumNode.Left = node.Left;

            return minimumNode;
        }
        else
        {
            int comparison = Comparer<T>.Default.Compare(node.Data, data);

            if (comparison < 0)
            {
                if (node.Right != null)
                {
                    node.Right  = DeleteNode(node.Right, data);

                    return node;
                }
            }
            else
            {
                if (node.Left != null)
                {
                    node.Left = DeleteNode(node.Left, data);

                    return node;
                }
            }
        }

        return node;
    }

    public int GetCount()
    {
        return count;
    }

    public void WidthTraversal()
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            Console.WriteLine(current.Data);

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

    public void DepthTraversal()
    {
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode<T> current = stack.Pop();
            Console.WriteLine(current.Data);

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

    public void ReversalDepthTraversal(TreeNode<T> node)
    {
        Console.WriteLine(node.Data);
        if (node.Left != null)
        {
            ReversalDepthTraversal(node.Left);
        }

        if (node.Right != null)
        {
            ReversalDepthTraversal(node.Right);
        }
    }
}