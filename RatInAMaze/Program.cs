using System;

namespace RatInAMaze
{
    class RatMaze
    { 

        void printSolution(int[,] solution)
        {
            int N = solution.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + solution[i, j] + " ");

                Console.WriteLine();
            }
        }

        // A utility function to check if x, y is valid index for N*N maze
        bool isSafe(int[,] maze, int x, int y)
        {
            int N = maze.GetLength(0);
            // If (x, y outside maze) return false
            return (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1);
        }

        bool solve(int[,] maze, int[,] solution, int x, int y)
        {
            int N = solution.GetLength(0);
            if (x == N - 1 && y == N - 1 && maze[x, y] == 1)
            {
                solution[x, y] = 1;
                return true;
            }
            if (isSafe(maze, x, y))
            {
                if (solution[x, y] == 1) 
                    return false;

                solution[x, y] = 1;
                if (solve(maze, solution, x + 1, y)) 
                    return true;
                if (solve(maze, solution, x, y + 1)) 
                    return true;
                if (solve(maze, solution, x - 1, y)) 
                    return true;
                if (solve(maze, solution, x, y - 1)) 
                    return true;

                solution[x, y] = 0;
                return false;
            }
            return false;
        }

        public bool solveMaze(int[,] maze)
        {
            int N = maze.GetLength(0);
            int[,] solution = new int[N, N];
            if (!solve(maze, solution, 0, 0))
            {
                Console.WriteLine("Solution doesn't exist.");
                return false;
            }
            else
            {
                
                printSolution(solution);
                return true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RatMaze rat = new RatMaze();

            int[,] maze = { { 1, 0, 0, 0 },
                                      { 1, 1, 0, 1 },
                                      { 0, 1, 0, 0 },
                                      { 1, 1, 1, 1 } };

            rat.solveMaze(maze);
        }
    }
}
