using System;
using System.Linq;

namespace Largest_Area_In_Matrix
{
    public class LargestAreaInMatrix
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

            bool[,] calculated = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            int bestCount = 0;
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!calculated[row, col])
                    {
                        int count = DepthFirstSearch(matrix, row, col, calculated);
                        if (bestCount < count)
                        {
                            bestCount = count;
                            indexRow = row;
                            indexCol = col;
                        }
                    }
                }
            }

            Console.WriteLine("{0}", bestCount);
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

        private static int DepthFirstSearch(int[,] array, int row, int col, bool[,] calc)
        {
            int result = 1;
            calc[row, col] = true;

            if ((row - 1 >= 0) && (array[row - 1, col] == array[row, col]) && !calc[row - 1, col])
            {
                result += DepthFirstSearch(array, row - 1, col, calc);
            }
            if ((row + 1 < array.GetLength(0)) && (array[row + 1, col] == array[row, col]) && !calc[row + 1, col])
            {
                result += DepthFirstSearch(array, row + 1, col, calc);
            }
            if ((col - 1 >= 0) && (array[row, col - 1] == array[row, col]) && !calc[row, col - 1])
            {
                result += DepthFirstSearch(array, row, col - 1, calc);
            }
            if ((col + 1 < array.GetLength(1)) && (array[row, col + 1] == array[row, col]) && !calc[row, col + 1])
            {
                result += DepthFirstSearch(array, row, col + 1, calc);
            }

            return result;
        }
    }
}