using System;
using System.Collections.Generic;
using BinarySearchTree;
namespace TwoSumInBST
{
    class Program
    {
        static void InOrder(Node n)
        {
            if (n == null) return;
            InOrder(n.left);
            nodelist.Add(n.value);
            InOrder(n.right);
        }
        static void PrintPairs(int sum, Node root)
        {
            nodelist.Clear();
            InOrder(root);
            
            HashSet<int> hs = new HashSet<int>();
            foreach(int x in nodelist)
            {
                if (hs.Contains(sum - x))
                    Console.WriteLine($"{sum} sum pair: {x} & {sum-x}");
                hs.Add(x);
            }
        }

        static List<int> nodelist = new List<int>();
        static void Main(string[] args)
        {
            BST tree = new BST();
            int[] numbers = { 21, 56, 33, 76, 24, 12, 4 };
            foreach (int x in numbers)
                tree.InsertNode(x);

            PrintPairs(80, tree.root);
        }
    }
}
