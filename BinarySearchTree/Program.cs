using System;

namespace BinarySearchTree
{
    public class Program
    {
        private static bool SearchInBST(int key, Node root)
        {
            if (root == null) return false;
            if (root.value == key) return true;
            return SearchInBST(key, root.left) || SearchInBST(key, root.right);
        }
        public static void Main(string[] args)
        {
            BST tree = new BST();
            tree.InsertNode(5);
            tree.InsertNode(21);
            tree.InsertNode(45);
            tree.InsertNode(76);
            tree.InsertNode(92);
            tree.InsertNode(7);
            tree.InsertNode(83);
            tree.InsertNode(26);
            tree.InsertNode(32);

            Console.WriteLine($"Searching 44: {SearchInBST(44,tree.root)}");
            Console.WriteLine($"Searching 21: {SearchInBST(21, tree.root)}");
            Console.WriteLine($"Searching 8: {SearchInBST(8, tree.root)}");
            Console.WriteLine($"Searching 26: {SearchInBST(26, tree.root)}");
            Console.WriteLine($"Searching 36: {SearchInBST(36, tree.root)}");
        }
    }
}
