using System;

namespace AVLTreeInsertion
{
    
    class Program
    {
        static void Main(string[] args)
        {
            #region example 1
            AVLTree tree = new AVLTree();

            /* Constructing tree given in the above figure */
            tree.root = tree.insert(tree.root, 10);
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 30);
            tree.root = tree.insert(tree.root, 40);
            tree.root = tree.insert(tree.root, 50);
            tree.root = tree.insert(tree.root, 25);

            /* The constructed AVL Tree would be
                30
                / \
            20    40
            / \       \
         10 25     50
            */
            Console.WriteLine("\nInorder traversal of constructed tree is : ");
            tree.inOrder(tree.root);
            #endregion

            #region example 2
            AVLTree tree1 = new AVLTree();

            /* Constructing tree given in the above figure */
            tree1.root = tree.insert(tree1.root, 9);
            tree1.root = tree.insert(tree1.root, 5);
            tree1.root = tree.insert(tree1.root, 10);
            tree1.root = tree.insert(tree1.root, 0);
            tree1.root = tree.insert(tree1.root, 6);
            tree1.root = tree.insert(tree1.root, 11);
            tree1.root = tree.insert(tree1.root, -1);
            tree1.root = tree.insert(tree1.root, 1);
            tree1.root = tree.insert(tree1.root, 2);

            /* The constructed AVL Tree would be
                     9
                    / \
                  1   10
                 / \     \
               0    5    11
              /    / \
           -1   2    6
            */
            Console.WriteLine("\nInorder traversal of constructed tree is :");
            tree.inOrder(tree1.root);

            tree1.root = tree1.delete(tree1.root, 10);

            /* The AVL Tree after deletion of 10
                    1
                   / \
                 0    9
               /      / \
             -1    5    11
                    / \
                 2     6
                    */
            
            Console.WriteLine("\nInorder traversal after deletion of 10 :");
            tree1.inOrder(tree1.root);
        }
        #endregion
    }
}

