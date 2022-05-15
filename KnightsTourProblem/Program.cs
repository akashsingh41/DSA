using System;

namespace KnightsTourProblem
{
    class Program
    {
        static bool knightsTour(int x, int y, int move_i, int[,] solution, int[] xMove, int[] yMove, int N)
        {
            int k, next_x, next_y;
            if (move_i == N * N)
                return true;

            /* Try all next moves from the current coordinate x, y */
            for (k = 0; k < 8; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if (isSafe(next_x, next_y, solution, N))
                {
                    solution[next_x, next_y] = move_i;
                    if (knightsTour(next_x, next_y, move_i + 1, solution, xMove, yMove, N))
                        return true;
                    else //backtracking                    
                    {
                        //Console.WriteLine($"backtracking: {x},{y}");
                        solution[next_x, next_y] = -1;
                    }
                }
            }

            return false;
        }
        static bool solveKnightsTour(int n)
        {
            int[,] solution = new int[n, n];
            /* Initialization of solution matrix */
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    solution[i, j] = -1;
                }

            /*
             * xMove[] and yMove[] define next move of Knight.
             * xMove[] is for next value of x coordinate
             * yMove[] is for next value of y coordinate 
             */
            int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Since the Knight is initially at the first block
            solution[0, 0] = 0;

            if (!knightsTour(0, 0, 1, solution, xMove, yMove, n))
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }
            else
            {
                printSolution(solution, n);
                return true;
            }
        }

        static bool isSafe(int x, int y, int[,] sol, int N)
        {
            return (x >= 0 && x < N && y >= 0 && y < N && sol[x, y] == -1);
        }

        static void printSolution(int[,] sol, int n)
        {
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                    Console.Write(sol[x, y].ToString("00") + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //solveKnightsTour(4);
            //solveKnightsTour(8);
            solveKnightsTour(16);
        }
    }
}
