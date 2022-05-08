using System;
using BinaryTree;

namespace CheckHeightBalancedBT
{
    class Program
    {
        static int findHeight(Node node)
        {
            if (node == null) return 0;
            return Math.Max(findHeight(node.left), findHeight(node.right)) + 1;
        }
        static bool IsBalanced(Node node)
        {
            if (node == null) return true;

            int lh = findHeight(node.left);
            int rh = findHeight(node.right);

            return Math.Abs(lh - rh) <= 1 && IsBalanced(node.left) && IsBalanced(node.right);
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.left.left.left = new Node(8);

            if (IsBalanced(tree.root))
            {
                Console.WriteLine("Tree is balanced");
            }
            else
            {
                Console.WriteLine("Tree is not balanced");
            }
        }
    }
}
