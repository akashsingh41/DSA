using System;
using BinaryTree;

namespace CountNodesOfCompleteBT
{
    class Program
    {
        //static int LeftHeight(Node node)
        //{
        //    int h = 0;
        //    while (node != null)
        //    {
        //        h++;
        //        node = node.left;
        //    }
        //    return h;
        //}

        //static int RightHeight(Node node)
        //{
        //    int h = 0;
        //    while (node != null)
        //    {
        //        h++;
        //        node = node.right;
        //    }
        //    return h;
        //}

        static int TotalNodes(Node node)
        {
            if (node == null) 
                return 0;

            //int lh = LeftHeight(node.left);
            //int rh = RightHeight(node.right);
            //if (lh == rh)
            //    return (int)Math.Pow(2,lh)-1;
            
            return (1 + TotalNodes(node.left) + TotalNodes(node.right));
        }
        static void Main(string[] args)
        {
            BT tree = new BT();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(9);
            tree.root.right.right = new Node(8);
            tree.root.left.left.left = new Node(6);
            tree.root.left.left.right = new Node(7);

            Console.Write(TotalNodes(tree.root));
        }
    }
}
