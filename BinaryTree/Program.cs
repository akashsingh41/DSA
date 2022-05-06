using System;
//using BinaryTree.Node;

namespace BinaryTree
{
    /*
     * Given a binary tree which has T nodes, you need to find the diameter of that binary tree. 
     * The diameter of a tree is the number of nodes on the longest path between two leaves in the tree.
     * Input:
     * First line contains two integers, T and X, number of nodes in the tree and value of the root.
     * Next lines contain details of nodes.
     * Each detail of node contains two lines. First lines contains a string and second line contains an integer, which denotes the path of the node and the value of the node respectively.
     *
     *String consists of only L or R. L denotes left child and R denotes right child. ( Look at the sample explanation for more details )
     *Output:
     *Print the diameter of the binary tree.
     * 
     * 
     */
    class Program
    {
        static int findHeight(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(findHeight(node.left), findHeight(node.right)) + 1;
        }

        static int findDiameter(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(findHeight(node.left) + findHeight(node.right) + 1, Math.Max(findDiameter(node.left), findDiameter(node.right)));
        }

        static void Main(string[] args)
        {
//            Sample Input
//            5 1
//            L
//            2
//            R
//            3
//            LL
//            4
//            LR
//            5

//            Output : 4

            BST myBinaryTree = new BST();
            string[] bt_dim = Console.ReadLine().Split(' ');
            int node_count = Int32.Parse(bt_dim[0]);
            int root_value = Int32.Parse(bt_dim[1]);
            myBinaryTree.AddNode(root_value);
            char[] node_path;
            Node current;
            for (int i = 0; i < node_count - 1; i++)
            {
                node_path = Console.ReadLine().ToCharArray();
                int path_length = node_path.Length;
                current = myBinaryTree.root;
                for (int j = 0; j < path_length; j++)
                {
                    if (node_path[j] == 'L')
                    {
                        if (current.left == null)
                            current.left = new Node();
                        current = current.left;
                    }
                    else if (node_path[j] == 'R')
                    {
                        if (current.right == null)
                            current.right = new Node();
                        current = current.right;
                    }
                }

                current.value = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine(findDiameter(myBinaryTree.root));
        }


    }
}