using System;
using System.Collections.Generic;
using BinaryTree;
namespace FixBSTTwoNodesSwapped
{
    class Program
    {
        static Node first, mid, last, previous;
        static void correctBST(Node node)
        {
            first = mid = last = previous = null;
            correctBSTUtility(node);

            if (first != null && last != null)
            {
                int temp = first.value;
                first.value = last.value;
                last.value = temp;
            }

            // Adjacent nodes swapped
            else if (first != null &&
                    mid != null)
            {
                int temp = first.value;
                first.value = mid.value;
                mid.value = temp;
            }
        }
        static void correctBSTUtility(Node root)
        {
            if (root != null)
            {
                correctBSTUtility(root.left);
                if (previous != null && root.value < previous.value)
                {
                    if (first == null)
                    {
                        first = previous;
                        mid = root;
                    }
                    else
                        last = root;
                }
                previous = root;
                correctBSTUtility(root.right);
            }
        }

        static List<int> nodelist = new List<int>();
        static void InOrder(Node n)
        {
            if (n == null) return;
            InOrder(n.left);
            nodelist.Add(n.value);
            InOrder(n.right);
        }
        static void printInorder(Node n)
        {
            nodelist.Clear();
            InOrder(n);
            foreach (int x in nodelist) { Console.Write(x + " "); }
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(6);
            tree.root.left = new Node(10);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            tree.root.right.right = new Node(12);
            tree.root.right.left = new Node(7);

            Console.WriteLine("Inorder Traversal of the original tree");
            printInorder(tree.root);
            correctBST(tree.root);
            Console.WriteLine("\nInorder Traversal of the fixed tree");
            printInorder(tree.root);
        }

    }
}


