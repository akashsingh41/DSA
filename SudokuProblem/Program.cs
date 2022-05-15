using System;

namespace SudokuProblem
{
    class Program
    {
        static bool isSafe(int[,] grid, int row, int col, int num)
        {

            // Check if we find the same num in the similar row, we return false
            for (int x = 0; x < N; x++)
                if (grid[row, x] == num)
                    return false;

            // Check if we find the same num in the similar column,
            // we return false
            for (int x = 0; x < N; x++)
                if (grid[x, col] == num)
                    return false;

            // Check if we find the same num in the particular 3*3 matrix, we return false
            int startRow = row - row % 3, startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[i + startRow, j + startCol] == num)
                        return false;

            return true;

        }
        static int N = 9;
        static bool solveSudoku(int[,] grid, int row, int col)
        {
            /*
             * if we have reached the 8th row and 9th column (0 indexed matrix), 
             * we are returning true to avoid further backtracking   
             */
            if (row == N - 1 && col == N)
                return true;

            // Check if column value becomes 9, we move to next row and column start from 0
            if (col == N)
            {
                row++;
                col = 0;
            }

            // Check if the current position of the grid already contains value >0,
            // we iterate for next column
            if (grid[row, col] != 0)
                return solveSudoku(grid, row, col + 1);

            for (int num = 1; num <= 9; num++)
            {

                // Check if it is safe to place the num (1-9)  in the given row ,col -> we move to next column
                if (isSafe(grid, row, col, num))
                {
                    /*  assigning the num in the current (row,col)  position of the grid and assuming our assigned num in the position is correct */
                    grid[row, col] = num;

                    // Checking for next possibility with next column
                    if (solveSudoku(grid, row, col + 1))
                        return true;
                }
                /* removing the assigned num , since our
                         assumption was wrong , and we go for next
                         assumption with diff num value   */
                grid[row, col] = 0;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[, ] problem = new int[,] {{3, 0, 6, 5, 0, 8, 4, 0, 0},
                                                              {5, 2, 0, 0, 0, 0, 0, 0, 0},
                                                              {0, 8, 7, 0, 0, 0, 0, 3, 1},
                                                              {0, 0, 3, 0, 1, 0, 0, 8, 0},
                                                              {9, 0, 0, 8, 6, 3, 0, 0, 5},
                                                              {0, 5, 0, 0, 9, 0, 6, 0, 0},
                                                              {1, 3, 0, 0, 0, 0, 2, 5, 0},
                                                              {0, 0, 0, 0, 0, 0, 0, 7, 4},
                                                              {0, 0, 5, 2, 0, 6, 3, 0, 0} };

            if (solveSudoku(problem, 0, 0))
            {
                //Console.WriteLine("Solution Found");
                printSolution(problem);
            }
            else
                Console.WriteLine("No Solution Found!");
        }

        static void printSolution(int[,] grid)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(grid[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}


# region GFG-JavaCode
////Initial Template for Java

//import java.util.*;
//import java.io.*;
//import java.lang.*;

//class Driver_class
//{
//    public static void main(String args[])
//    {

//        Scanner sc = new Scanner(System.in);
//        int t = sc.nextInt();

//        while (t-- > 0)
//        {
//            int grid[][] = new int[9][9];
//            for (int i = 0; i < 9; i++)
//            {
//                for (int j = 0; j < 9; j++)
//                    grid[i][j] = sc.nextInt();
//            }

//            Solution ob = new Solution();

//            if (ob.SolveSudoku(grid) == true)
//                ob.printGrid(grid);
//            else
//                System.out.print("NO solution exists");
//            System.out.println();

//        }
//    }
//}



//// } Driver Code Ends


////User function Template for Java

//class Solution
//{
//    //Function to find a solved Sudoku. 
//    static boolean SolveSudoku(int grid[][])
//    {
//        // add your code here
//        for (int i = 0; i < grid.length; i++)
//        {
//            for (int j = 0; j < grid[0].length; j++)
//            {
//                if (grid[i][j] == 0)
//                {
//                    for (int k = 1; k <= 9; k++)
//                    {
//                        if (isSafe(i, j, k, grid))
//                        {
//                            grid[i][j] = k;
//                            if (SolveSudoku(grid) == true)
//                                return true;
//                            else
//                                grid[i][j] = 0;

//                        }

//                    }//end of checking from 1 to 9 and no number can be inserted here
//                     //due to previous wrong selection of input so we backtrack
//                    return false;//backtracking
//                }
//            }
//        }
//        return true;
//    }
//    static boolean isSafe(int i, int j, int k, int grid[][])
//    {
//        for (int x = 0; x < 9; x++)
//            if (grid[i][x] == k || grid[x][j] == k)
//                return false;
//        int sx = (i / 3) * 3;
//        int sy = (j / 3) * 3;
//        for (int x = sx; x < sx + 3; x++)
//        {
//            for (int y = sy; y < sy + 3; y++)
//            {
//                if (grid[x][y] == k)
//                    return false;
//            }
//        }
//        return true;
//    }

//    //Function to print grids of the Sudoku.
//    static void printGrid(int grid[][])
//    {
//        // add your code here
//        for (int i = 0; i < 9; i++)
//        {
//            for (int j = 0; j < 9; j++)
//            {
//                System.out.print(grid[i][j] + " ");
//            }
//            //System.out.println();
//        }
//    }
//}

#endregion