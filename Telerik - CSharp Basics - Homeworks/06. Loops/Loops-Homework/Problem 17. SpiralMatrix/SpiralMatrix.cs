using System;

namespace Problem_17.SpiralMatrix
{
    public class SpiralMatrix
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[,] spiralMatrix = new int[N, N];

            FillMatrix(spiralMatrix, N);

            PrintMatrix(spiralMatrix, N);
        }

        private static void FillMatrix(int[,] spiralMatrix, int N)
        {
            int maxValue = N * N;

            int row = 0;
            int col = 0;
            string direction = "right";

            for (int i = 1; i <= maxValue; i++)
            {
                // check for changing the direction

                if (direction == "right" && (col > (N - 1) || spiralMatrix[row, col] != 0))
                {
                    direction = "down";
                    row++;
                    col--;
                }

                if (direction == "down" && (row > (N - 1) || spiralMatrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }

                if (direction == "left" && (col < 0 || spiralMatrix[row, col] != 0))
                {
                    direction = "up";
                    row--;
                    col++;
                }

                if (direction == "up" && (row < 0 || spiralMatrix[row, col] != 0))
                {
                    direction = "right";
                    row++;
                    col++;
                }

                // fill the current element

                spiralMatrix[row, col] = i;

                // go to the next element in this direction

                if (direction == "right")
                {
                    col++;
                }

                if (direction == "down")
                {
                    row++;
                }

                if (direction == "left")
                {
                    col--;
                }

                if (direction == "up")
                {
                    row--;
                }
            }
        }

        private static void PrintMatrix(int[,] spiralMatrix, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0} ", spiralMatrix[i, j]);
                }

                Console.WriteLine();
            }
        }

    }
}