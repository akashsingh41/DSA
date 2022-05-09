using System;


namespace ConstructBTFromInOrderAndPreOrder
{

    public class Node
    {
        public char value;
        public Node left;
        public Node right;

        public Node() { }
        public Node(char i) { this.value = i; }

        public char Display() { return this.value; }
    }
    class Program
    {
        static void Main(string[] args)
        {            
            char[] inOrder = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
            char[] preOrder = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            int length = inOrder.Length;
            Node root = BuildTree(inOrder, preOrder, 0, length - 1);

            // building the tree by printing inorder traversal
            Console.WriteLine("Inorder traversal of constructed tree is : ");
            printInorder(root);
        }

        static int preIndex = 0;
        static Node BuildTree(char[] inOrder, char[] preOrder, int inStart, int inEnd)
        {
            if (inStart > inEnd) return null;

            Node node = new Node(preOrder[preIndex++]);
            int inIndex = search(inOrder, inStart, inEnd, node.value);

            node.left = BuildTree(inOrder, preOrder, inStart, inIndex - 1);
            node.right = BuildTree(inOrder, preOrder, inIndex + 1, inEnd);

            return node;
        }

        static int search(char[] inOrder, int inStart, int inEnd, char data)
        {
            int i = 0;
            for (i = inStart; i <= inEnd; i++)
            {
                if (inOrder[i] == data)
                    return i;
            }
            return i;
        }

        static void printInorder(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.value + " ");

            /* now recur on right child */
            printInorder(node.right);
        }
    }
}
