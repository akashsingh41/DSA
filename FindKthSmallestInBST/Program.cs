using System;
using System.Collections.Generic;
using BinarySearchTree;

namespace FindKthSmallestInBST
{
    class Program
    {
        static List<int> nodelist = new List<int>();

        static void InOrder(Node n)
        {
            if (n == null) return;
            InOrder(n.left);
            nodelist.Add(n.value);
            InOrder(n.right);
        }

        static int KthSmallest(Node node, int k)
        {
            nodelist.Clear();
            InOrder(node);

            return nodelist[k - 1];
        }
        static void Main(string[] args)
        {
            BST tree = new BST();
            int[] keys = {20, 8, 22, 4, 12, 10, 14};

            foreach (int x in keys)
                tree.InsertNode( x);
            int k = 4;
            Console.WriteLine($"{k}th smallest number in BST: {KthSmallest(tree.root,k)}");

        }
    }
}
