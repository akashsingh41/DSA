using System;
using BinaryTree; 


namespace HeightOfBT
{
    class Program
    {

        static int findHeight(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(findHeight(node.left), findHeight(node.right)) + 1;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Height of tree is : " + findHeight(tree.root));
        }
    }
}
