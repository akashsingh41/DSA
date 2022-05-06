using System;

namespace TreeTraversal
{
    class Program
    {
        public static void InOrder(Node root) 
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write($"{root.Display()} ");
                InOrder(root.right);
            }
        }

        public static void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write($"{root.Display()} ");
                PreOrder(root.left);                
                PreOrder(root.right);
            }
        }

        public static void PostOrder(Node root)
        {
            if (root != null)
            {                
                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write($"{root.Display()} ");
            }
        }

        public static void Main(string[] args)
        {
            BST tree = new BST();
            tree.AddNode(23);
            tree.AddNode(45);
            tree.AddNode(16);
            tree.AddNode(37);
            tree.AddNode(3);
            tree.AddNode(99);
            tree.AddNode(22);
            Console.WriteLine("In-Order Traversal:-");
            InOrder(tree.root);

            Console.WriteLine("\nPre-Order Traversal:-");
            PreOrder(tree.root);

            Console.WriteLine("\nPost-Order Traversal:-");
            PostOrder(tree.root);

        }
    }
}