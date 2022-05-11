using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTreeInsertion
{
    public class AVLTree
    {
        public Node root;
        private int height(Node N)
        {
            if(N==null) return 0;
            return N.height;
        }
        private int balance(Node N)
        {
            if (N == null) return 0;
            return height(N.left) - height(N.right);
        }
        public Node insert(Node n, int key)
        {
            if (n == null)
                n = new Node(key, null, null);
            else
            if (key < n.data)
            {
                n.left = insert(n.left, key);
            }
            else if (key > n.data)
            {
                n.right = insert(n.right, key);
            }
            else 
                return n;//no duplicates

            n.height = 1 + Math.Max(height(n.left), height(n.right));
            
            //If this node becomes unbalanced, then there are 4 scenarios
            //Left Left Case
            if (balance(n) > 1 && key < n.left.data)
                return rightRotate(n);

            // Right Right Case
            if (balance(n) < -1 && key > n.right.data)
                return leftRotate(n);

            // Left Right Case
            if (balance(n) > 1 && key > n.left.data)
            {
                n.left = leftRotate(n.left);
                return rightRotate(n);
            }

            // Right Left Case
            if (balance(n) < -1 && key < n.right.data)
            {
                n.right = rightRotate(n.right);
                return leftRotate(n);
            }

            /* return the (unchanged) node pointer */
            return n;
        }
        private Node minValueNode(Node node)
        {
            Node current = node;
            /* loop down to find the leftmost leaf */
            while (current.left != null)
                current = current.left;
            return current;
        }
        public Node delete(Node n, int key)
        {
            if (n == null) return n;

            if (key < n.data)
                n.left = delete(n.left, key);

            else if (key > n.data)
                n.right = delete(n.right, key);

            else 
            {
                // node with only one child or no child
                if ((n.left == null) || (n.right == null))
                {
                    Node temp = null;
                    if (temp == n.left)
                        temp = n.right;
                    else
                        temp = n.left;

                    // No child case
                    if (temp == null)
                    {
                        temp = n;
                        n = null;
                    }
                    else // One child case
                        n = temp; // Copy the contents of the non-empty child
                }
                else
                {

                    // node with two children: Get the inorder successor (smallest in the right subtree)
                    Node temp = minValueNode(n.right);

                    // Copy the inorder successor's data to this node
                    n.data = temp.data;

                    // Delete the inorder successor
                    n.right = delete(n.right, temp.data);
                }
            }

            if (n == null)
                return n;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE
            n.height = Math.Max(height(n.left), height(n.right)) + 1;

            // If this node becomes unbalanced, then there are 4 cases
            // Left Left Case
            if (balance(n) > 1 && balance(n.left) >= 0)
                return rightRotate(n);

            // Left Right Case
            if (balance(n) > 1 && balance(n.left) < 0)
            {
                n.left = leftRotate(n.left);
                return rightRotate(n);
            }

            // Right Right Case
            if (balance(n) < -1 && balance(n.right) <= 0)
                return leftRotate(n);

            // Right Left Case
            if (balance(n) < -1 && balance(n.right) > 0)
            {
                n.right = rightRotate(n.right);
                return leftRotate(n);
            }
            return n;
        }
        private Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation
            x.right = y;
            y.left = T2;

            // Update heights
            y.height = Math.Max(height(y.left), height(y.right)) + 1;
            x.height = Math.Max(height(x.left), height(x.right)) + 1;

            // Return new root
            return x;
        }
        private Node leftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation
            y.left = x;
            x.right = T2;

            // Update heights
            x.height = Math.Max(height(x.left), height(x.right)) + 1;
            y.height = Math.Max(height(y.left), height(y.right)) + 1;

            // Return new root
            return y;
        }
        public void inOrder(Node node)
        {
            if (node != null)
            {                
                inOrder(node.left);
                Console.Write(node.data + " ");
                inOrder(node.right);
            }
        }
    }
}
