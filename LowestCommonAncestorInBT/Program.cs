using System;
using BinaryTree;
using System.Collections.Generic;
namespace LowestCommonAncestorInBT
{
    class Program
    {
        static Node findLCA(Node node, int x, int y)
        {
            if (node == null) return null;
            if (node.value == x || node.value == y) 
                return node;

            Node leftLCA = findLCA(node.left, x, y);
            Node rightLCA = findLCA(node.right, x, y);

            if (leftLCA != null && rightLCA != null) 
                return node;

            return (leftLCA != null) ? leftLCA : rightLCA;
        }
        
        static void Main(string[] args)
        {
            BT tree = new BT();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);

            Console.WriteLine("LCA(4, 5): " + findLCA(tree.root, 4, 5).value);
            Console.WriteLine("LCA(4, 6): " + findLCA(tree.root, 4, 6).value);
            Console.WriteLine("LCA(3, 4): " + findLCA(tree.root, 3, 4).value);
            Console.WriteLine("LCA(2, 4): " + findLCA(tree.root, 2, 4).value);
        }
    }
}
