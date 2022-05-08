using System;
using BinaryTree;
namespace ChildrenSumParent
{
    class Program
    {

        static bool IsSumProperty(Node node)
        {
            if ((node == null) || (node.left == null && node.right == null)) 
                    return true;
            else
            {
                int left = node.left==null ? 0 : node.left.value;
                int right = node.right == null ? 0 : node.right.value;
                if (node.value == (left + right))
                {
                    return IsSumProperty(node.left) && IsSumProperty(node.right);
                }
                else 
                    return false;
            }
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.right = new Node(2);

            if (IsSumProperty(tree.root))
            {
                Console.WriteLine("The given tree satisfies children sum property");
            }
            else
            {
                Console.WriteLine("The given tree does not satisfy children sum property");
            }
        }
    }
}
