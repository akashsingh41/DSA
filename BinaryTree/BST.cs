using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public static int findHeight(Node node)
        {
            if (node == null)
                return 0;
            else
                return Math.Max(findHeight(node.left), findHeight(node.right)) + 1;
        }
        public void AddNode(int x)
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
    }
}
