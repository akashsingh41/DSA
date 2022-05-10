using System;

namespace BinarySearchTree
{
    public class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public void InsertNode(int x)
        {
            Node new_node = new Node(x);
            if (root == null)
            {
                root = new_node;
            }
            else
            {
                Node current, parent;
                current = root;
                while (true)
                {
                    parent = current;
                    if (current == null)
                    {
                        current = new_node;
                        break;
                    }

                    if (x < current.value)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = new_node;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = new_node;
                            break;
                        }
                    }
                }
            }
        }

        public int Height(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(Height(node.left), Height(node.right)) + 1;
        }
    }
}
