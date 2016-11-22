using System;
using WalkInMatrix.Models;

namespace WalkInMatrix.IOProviders
{
    internal class ConsoleOutput
    {
        internal static void PrintMatrix(Matrix matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var position = new Position(row, col);
                    Console.Write(string.Format("{0,3}", matrix[position]));
                }

                Console.WriteLine();
            }
        }
    }
}
