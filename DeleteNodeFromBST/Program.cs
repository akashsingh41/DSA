using System;
using BinarySearchTree;

namespace DeleteNodeFromBST
{
    class Program
    {
        static Node DeleteNodeWithParent(Node node, int x)
        {
            if (node == null) return node;
            if (node.value > x)
            { 
                node.left = DeleteNode(node.left, x);
                return node;
            }
            if (node.value < x) 
            { 
                node.right = DeleteNode(node.right, x);
                return node;
            }

            //if either or both children absent
            if (node.left == null)
            {
                Node temp = node.right;
                return temp;
            }
            if (node.right == null)
            {
                Node temp = node.left;
                return temp;
            }

            Node successorParent = node;

            //find successor
            Node successor = node.right;
            while (successor.left != null)
            {
                successorParent = successor;
                successor = successor.left;
            }

            // Delete successor. Since successor is always left child of its parent, we can safely make successor's right child as left of its parent.
            // If there is no succ, then assign successor->right to successorParent->right
            if (successorParent != node)
                successorParent.left = successor.right;
            else
                successorParent.right = successor.right;

            node.value = successor.value;

            return node;
        }
        static int MinValue(Node node) 
        {
            int min = node.value;
            while (node.left != null)
            {
                min = node.left.value;
                node = node.left;
            }
            return min;
        }
        static Node DeleteNode(Node node, int x)
        {
            /* Base Case: If the tree is empty */
            if (node == null) 
                return node;

            // if key is same as root's key, then this is the node to be deleted
            if (x < node.value)
                node.left = DeleteNode(node.left, x);
            else if (x > node.value)
                node.right = DeleteNode(node.right, x);
            else
            {
                //node with only one child or no child
                if (node.left == null) 
                    return node.right;
                if (node.right == null) 
                    return node.left;

                // node with two children: Get the InOrder successor (smallest in the right subtree)
                node.value = MinValue(node.right);

                // Delete the inorder successor
                node.right = DeleteNode(node.right, node.value);
            }
            return node;
        }
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.InsertNode(50);
            tree.InsertNode(30);
            tree.InsertNode(20);
            tree.InsertNode(40);
            tree.InsertNode(70);
            tree.InsertNode(60);
            tree.InsertNode(80);

            Console.WriteLine("Inorder traversal of the given tree");
            InOrder(tree.root);

            Console.WriteLine("\nDelete 20\n");
            tree.root = DeleteNode(tree.root, 20);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder(tree.root);

            Console.WriteLine("\nDelete 30\n");
            tree.root = DeleteNode(tree.root, 30);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder(tree.root);

            Console.WriteLine("\nDelete 50\n");
            tree.root = DeleteNode(tree.root, 50);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder(tree.root);
        }

        static void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write(root.value + " ");
                InOrder(root.right);
            }
        }
    }
}
