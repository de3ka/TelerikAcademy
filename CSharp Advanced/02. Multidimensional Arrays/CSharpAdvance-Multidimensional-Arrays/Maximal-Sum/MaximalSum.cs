using System;
using System.Linq;

namespace Maximal_Sum
{
    public class MaximalSum
    {
        public static void Main()
        {
            int[] dimentions = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int N = dimentions[0];
            int M = dimentions[1];
            int[][] source = new int[N][];
            int[,] matrix = new int[N, M];

            for (int row = 0; row < N; row++)
            {
                source[row] =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            matrix = To2D(source);

            long maxSum = long.MinValue;
            long tmpSum = 0;
            long maxRow = 0;
            long maxCol = 0;

            for (int row = 0; row < N - 2; row++)
            {
                for (int col = 0; col < M - 2; col++)
                {
                    tmpSum = CalcSum(row, col, matrix);

                    if (tmpSum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = tmpSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }

        private static T[,] To2D<T>(T[][] source)
        {
            int FirstDim = source.Length;
            int SecondDim = source.GroupBy(row => row.Length).Single().Key;
            var result = new T[FirstDim, SecondDim];

            for (int i = 0; i < FirstDim; ++i)
            {
                for (int j = 0; j < SecondDim; ++j)
                {
                    result[i, j] = source[i][j];
                }
            }

            return result;
        }

        private static int CalcSum(int startRow, int startCol, int[,] matrix)
        {
            int sum = 0;

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    sum = sum + matrix[row, col];
                }
            }

            return sum;
        }
    }
}