using System;
using System.Collections.Generic;
using BinaryTree;

namespace IterativePreOrderTraversal
{
    class Program
    {
        static void IterativePreOrder(Node root) 
        {
            if (root == null) return;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                Node current = stack.Pop();
                Console.Write(current.value + " ");
                if (current.right != null)
                    stack.Push(current.right);
                if (current.left != null)
                    stack.Push(current.left);
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
            tree.root.right.left = new Node(2);
            IterativePreOrder(tree.root);
        }
    }
}
