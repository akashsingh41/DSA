using System;
using BinaryTree;

namespace PrintNodesAtKDistance
{
    class Program
    {
        static void PrintNodesAtKDistance(Node node, int k)
        {
            if (node == null || k < 0) return;

            if (k == 0)
            {
                if (node != null)
                    Console.Write($"{node.value} ");              
            }
            else
            {
                PrintNodesAtKDistance(node.left, k - 1);
                PrintNodesAtKDistance(node.right, k - 1);
            }
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(8);

            PrintNodesAtKDistance(tree.root, 2);

        }
    }
}
