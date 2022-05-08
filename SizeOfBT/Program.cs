using System;
using BinaryTree;


namespace SizeOfBT
{
    class Program
    {
        public static int sizeOfBinaryTree(Node node)
        {
            return node == null ? 0 : sizeOfBinaryTree(node.left) + sizeOfBinaryTree(node.right) + 1;
        }

        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("The size of this Binary Tree is : " + sizeOfBinaryTree(tree.root));
        }
    }
}
