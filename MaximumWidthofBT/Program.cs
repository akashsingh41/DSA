using System;
using System.Collections.Generic;
using BinaryTree;

namespace MaximumWidthofBT
{
    class Program
    {
        #region By Level Order Traversal - taking O(n^2) in worst case : Approach#1
        static int findHeight(Node node)
        {
            if (node == null) 
                return 0;
            else 
                return Math.Max(findHeight(node.left),findHeight(node.right)) + 1;        
        }
        static int GetWidth(Node node, int level)
        {
            if (node == null) 
                return 0;
            if (level == 1) 
                return 1;
            else
                if (level > 1) 
                    return GetWidth(node.left, level - 1) + GetWidth(node.right, level - 1);            
                return 0;
        }
        static int GetMaxWidth(Node node)
        {
            int max_width = 0;
            int height = findHeight(node);
            for (int i = 0; i <= height; i++)
            {
                int width = GetWidth(node, i);
                if (max_width < width)
                    max_width = width;
            }
            return max_width;
        }
        #endregion

        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.right = new Node(8);
            tree.root.right.right.left = new Node(6);
            tree.root.right.right.right = new Node(7);

            Console.WriteLine("Maximum width is " + GetMaxWidthUsingQueue(tree.root)); 
            //Console.WriteLine("Maximum width is " + GetMaxWidth(tree.root)); using Approach#1
        }

        static int GetMaxWidthUsingQueue(Node root)
        {
            if (root == null) return 0;

            int maxwidth = 0;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int count = q.Count;
                maxwidth = Math.Max(maxwidth, count);
                while (count-- > 0)
                {
                    Node temp = q.Dequeue();
                    if(temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);
                }                
            }
            return maxwidth;
        }
    }
}
