using System;
using System.Collections.Generic;
using BinaryTree;


namespace LeftRightViewOfBT
{
    class Program
    {
        static int current_level = 0;
        static Queue<int> leftViewQ = new Queue<int>();

        static void LeftMostNode(Node node, int level)
        {
            if (node == null) return;
            if (current_level < level)
            {
                leftViewQ.Enqueue(node.value);
                current_level = level;
            }                        
             
            LeftMostNode(node.left, level + 1);
            LeftMostNode(node.right, level + 1);

        }
        static List<int> LeftView(Node node)
        {
            List<int> output = new List<int>();
            LeftMostNode(node, 1);
            while (leftViewQ.Count > 0)
            {
                output.Add(leftViewQ.Dequeue());
            }
            return output;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(10);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(7);
            tree.root.left.right = new Node(8);
            tree.root.right.right = new Node(15);
            tree.root.right.left = new Node(12);
            tree.root.right.right.left = new Node(14);

            Console.WriteLine("Leftt View: ");
            foreach ( int x in LeftView(tree.root))
                Console.Write($"{x} ");

            Console.WriteLine("\n\nRight View: ");
            RightView(tree.root);
        }

        static void RightView(Node node)
        {
            PrintRightView(node, 1);
        }

        static int this_level = 0;
        static void PrintRightView(Node node, int level)
        {
            if (node == null) return;
            if (this_level < level)
            {
                Console.Write($"{node.value} ");
                this_level = level;
            }

            PrintRightView(node.right, level + 1);
            PrintRightView(node.left, level + 1);
        }
    }
}
