using System;
using BinarySearchTree;
using System.Collections.Generic;

namespace FloorCielInBST
{
    class Program
    {
        static List<int> inOrderList = new List<int>();
        static void InOrder(Node node) 
        {
            if (node == null) return;

            InOrder(node.left);
            inOrderList.Add(node.value);
            InOrder(node.right);
        }
        static int Floor(Node node, int k)
        {
            if (inOrderList.Count == 0)
                InOrder(node);
            

                int[] inOrder = inOrderList.ToArray();
                int i = 0;
                while (k >= inOrder[i] && i < inOrder.Length) 
                {
                    i++;
                }
                return inOrder[i - 1];
        }

        static int Ceil(Node node, int k)
        {
            if (inOrderList.Count == 0)
                InOrder(node);

                int[] inOrder = inOrderList.ToArray();
                int i = 0;
                while (k >= inOrder[i] && i < inOrder.Length)
                {
                    i++;
                }
                return inOrder[i];
        }

        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.InsertNode(5);
            tree.InsertNode(21);
            tree.InsertNode(45);
            tree.InsertNode(76);
            tree.InsertNode(92);
            tree.InsertNode(7);
            tree.InsertNode(83);
            tree.InsertNode(26);
            tree.InsertNode(32);

            Console.WriteLine($"Floor of 25: {Floor(tree.root, 25)}");
            Console.WriteLine($"Floor of 45: {Floor(tree.root, 45)}");
            Console.WriteLine($"Floor of 5: {Floor(tree.root, 5)}");
            Console.WriteLine($"Ceil of 25: {Ceil(tree.root, 25)}");
            Console.WriteLine($"Ceil of 45: {Ceil(tree.root, 45)}");
            Console.WriteLine($"Ceil of 5: {Ceil(tree.root, 5)}");
        }
    }
}
