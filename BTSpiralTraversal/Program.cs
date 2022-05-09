using System;
using System.Collections.Generic;
using BinaryTree;

namespace BTSpiralTraversal
{
    class Program
    {
        static List<int> output = new List<int>();
        static int findHeight(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(findHeight(node.left), findHeight(node.right)) + 1;
        }
        static void TraverseLevel(Node node, int level, bool l2r) 
        {
            if (node == null) return;
            if (level == 1)
                //Console.Write(node.value + " ");
                output.Add(node.value);

            else
            {
                if (level > 1)
                {
                    if (l2r)
                    {
                        TraverseLevel(node.left, level - 1, l2r);
                        TraverseLevel(node.right, level - 1, l2r);
                    }
                    else
                    {
                        TraverseLevel(node.right, level - 1, l2r);
                        TraverseLevel(node.left, level - 1, l2r);
                    }

                }
            }            
        }
        static List<int> SpiralTraversal(Node node) 
        {
            int height = findHeight(node);
            bool l2r = true;
            for (int i = 0; i <= height; i++)
            {
                TraverseLevel(node, i, l2r);
                l2r = !l2r;
            }
            return output;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(7);
            tree.root.left.right = new Node(6);
            tree.root.right.left = new Node(5);
            tree.root.right.right = new Node(4);
            Console.WriteLine("Spiral Order traversal of Binary Tree is ");
            foreach (int x in SpiralTraversal(tree.root)) Console.Write(x+" "); ;
        }
    }
}
