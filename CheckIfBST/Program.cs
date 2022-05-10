using System;
using System.Collections.Generic;
using BinarySearchTree;
using BinaryTree;

namespace CheckIfBST
{
    /*
     * METHOD 1 (Simple but Wrong) : For each node, check if the left node of it is smaller than the node and right node of it is greater than the node. 
     */
    //bool isBST(Node node)
    //{
    //	if (node == null)
    //		return true;
    //	if (node.left != null && node.left.data > node.data)
    //		return false;
    //	if (node.right != null && node.right.data < node.data)
    //		return false;
    //	if (!isBST(node.left) || !isBST(node.right))
    //		return false;
    //	return true;
    //}

    /*
	 * METHOD 2 (Correct but not efficient) : For each node, check if max value in left subtree is smaller than the node and min value in right subtree greater than the node.
	 */
    //bool isBST(Node node)
    //{
    //    if (node == null)
    //        return true;
    //    if (node.left != null && maxValue(node.left) >= node.data)
    //        return false;
    //    if (node.right != null && minValue(node.right) <= node.data)
    //        return false;
    //    if (!isBST(node.left) || !isBST(node.right))
    //        return false;
    //    return true;
    //}

    /*
     * METHOD 3 (Correct and Efficient): Method 2 above runs slowly since it traverses over some parts of the tree many times.A better solution looks at each node only once. 
     * The trick is to write a utility helper function isBSTUtil(struct node* node, int min, int max) that traverses down the tree keeping track of the narrowing min and max 
     * allowed values as it goes, looking at each node only once.The initial values for min and max should be INT_MIN and INT_MAX — they narrow from there.
     *
     * Note: This method is not applicable if there are duplicate elements with value INT_MIN or INT_MAX.
     */
    //public virtual bool BST { get  return isBSTUtil(root, int.MinValue, int.MaxValue);   }

    /* Returns true if the given tree is a BST and its values are >= min and <= max. */
    //public virtual bool isBSTUtil(Node node, int min, int max)
    //{
    //    /* an empty tree is BST */
    //    if (node == null) return true;

    //    /* false if this node violates the min/max constraints */
    //    if (node.data < min || node.data > max) return false;

    //    /* otherwise check the subtrees recursively tightening the min/max constraints */
    //    // Allow only distinct values
    //    return (isBSTUtil(node.left, min, node.data - 1) && isBSTUtil(node.right, node.data + 1, max));
    //}

    /*
     * METHOD 4(Using In-Order Traversal) :
     * 1) Do In-Order Traversal of the given tree and store the result in a temp array. 
     * 2) This method assumes that there are no duplicate values in the tree
     * 3) Check if the temp array is sorted in ascending order, if it is, then the tree is BST.
     */

    class Program
    {
        static bool IsBST(BinaryTree.Node node)
        {
            nodelist.Clear();
            InOrder(node);
            for (int i=0;i<nodelist.Count-1;i++)
            {
                if (nodelist[i] > nodelist[i + 1])
                return false;
            }
            return true;
               
        }

        static List<int> nodelist = new List<int>();
        static void InOrder(BinaryTree.Node n)
        {
            if (n == null) return;
            InOrder(n.left);
            nodelist.Add(n.value);
            InOrder(n.right);
        }
        static void Main(string[] args)
        {
            BT tree2 = new BT();
            tree2.root = new BinaryTree.Node(4);
            tree2.root.left = new BinaryTree.Node(2);
            tree2.root.right = new BinaryTree.Node(5);
            tree2.root.left.left = new BinaryTree.Node(1);
            tree2.root.left.right = new BinaryTree.Node(3);
            Console.WriteLine(IsBST(tree2.root));

            BT tree1 = new BT(); 
            tree1.root = new BinaryTree.Node(3);
            tree1.root.left = new BinaryTree.Node(2);
            tree1.root.right = new BinaryTree.Node(5);
            tree1.root.left.left = new BinaryTree.Node(1);
            tree1.root.left.right = new BinaryTree. Node(4);
            Console.WriteLine(IsBST(tree1.root));
        }
    }
}
