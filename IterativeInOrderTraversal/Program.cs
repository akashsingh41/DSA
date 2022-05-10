using System;
using BinaryTree;
using System.Collections.Generic;
namespace IterativeInOrderTraversal
{
    class Program
    {
        static void IterativeInOrder(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                Console.Write(current.value + " ");
                current = current.right;
            }
        }
        

        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            
            IterativeInOrder(tree.root);
        }
    }
}
