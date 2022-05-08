using System;
using BinaryTree;
namespace FindMinMaxInBT
{
    class Program
    {
        static int findMax(Node node)
        {
            if (node == null) return int.MinValue;

            int currentMax = node.value;
            int maxFromLeft = findMax(node.left);
            int maxFromRight = findMax(node.right);
            
            if (currentMax < maxFromLeft) 
                currentMax = maxFromLeft;

            if (currentMax < maxFromRight) 
                currentMax = maxFromRight;
            
            return currentMax;
        }

        static int findMin(Node node)
        {
            if (node == null) return int.MaxValue;

            int currentMin = node.value;
            int minFromLeft = findMin(node.left);
            int minFromRight = findMin(node.right);

            if (currentMin > minFromLeft)
                currentMin = minFromLeft;

            if (currentMin > minFromRight)
                currentMin = minFromRight;

            return currentMin;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(2);
            tree.root.left = new Node(7);
            tree.root.right = new Node(5);
            tree.root.left.right = new Node(6);
            tree.root.left.right.left = new Node(1);
            tree.root.left.right.right = new Node(11);
            tree.root.right.right = new Node(9);
            tree.root.right.right.left = new Node(4);
            
            Console.WriteLine("Maximum element is " + findMax(tree.root));
            Console.WriteLine("Minimum element is " + findMin(tree.root));
        }
    }
}
