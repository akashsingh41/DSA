using System;
using BinaryTree;

namespace ConvertBTtoDLL
{
    class Program
    {
        static Node BT2DLL(Node node)
        {
            if (node == null) return node;
            
            node = ConvertBT2DLL(node);

            while (node.left != null)
                node = node.left;

            return node;
        }

        static Node ConvertBT2DLL(Node node)
        {
            if (node == null) return node;
            if (node.left != null)
            {
                Node left = ConvertBT2DLL(node.left);
                while (left.right != null)
                    left = left.right;

                left.right = node;
                node.left = left;
            }

            if (node.right != null) 
            {
                Node right = ConvertBT2DLL(node.right);
                while (right.left != null)
                    right = right.left;

                right.left = node;

                node.right = right;
            }
            return node;
        }

        static void Main(string[] args)
        {
            BT tree = new BT();
            
            tree.root = new Node(10);
            tree.root.left = new Node(12);
            tree.root.right = new Node(15);
            tree.root.left.left = new Node(25);
            tree.root.left.right = new Node(30);
            tree.root.right.left = new Node(36);

            // Convert to DLL
            Node head = BT2DLL(tree.root);

            // Print the converted list
            PrintDLL(head);
        }

        static void PrintDLL(Node node)
        {
            while (node != null)
            {
                Console.Write($"{node.value} ");
                node = node.right;
            }
        }
    }
}
