using System;
using BinaryTree;

namespace BurnBTFromTargetNode
{
    class Program
    {
        static int TimeToBurnDown(Node root, Node target)
        {
            return 0;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(12);
            tree.root.left = new Node(13);
            tree.root.right = new Node(10);
            tree.root.right.left = new Node(14);
            tree.root.right.right = new Node(15);
            Node left = tree.root.right.left;
            Node right = tree.root.right.right;
            left.left = new Node(21);
            left.right = new Node(24);
            right.left = new Node(22);
            right.right = new Node(23);

            Console.WriteLine("Tiome to burn down:" + TimeToBurnDown(tree.root, left));
        }
    }
}
