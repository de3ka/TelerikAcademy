using System;

namespace Fill_The_Matrix
{
    public class FillTheMatrix
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[,] matrix = new int[rows, cols];
            char symbol = Console.ReadLine()[0];

            switch (symbol)
            {
                case 'a':
                    FillMatrixA(matrix);
                    break;
                case 'b':
                    FillMatrixB(matrix);
                    break;
                case 'c':
                    FillMatrixC(matrix);
                    break;
                case 'd':
                    FillMatrixD(matrix);
                    break;
            }

            PrintMatrix(matrix);
        }

        private static void FillMatrixA(int[,] matrix)
        {
            for (int col = 0, index = 1; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++, index++)
                {
                    matrix[row, col] = index;
                }
            }
        }

        private static void FillMatrixB(int[,] matrix)
        {
            bool isDirDown = true;
            for (int col = 0, row = 0, index = 1; col < matrix.GetLength(1); col++)
            {
                while (row >= 0 && row < matrix.GetLength(0))
                {
                    matrix[row, col] = index++;
                    row += isDirDown ? +1 : -1;
                }

                isDirDown = !isDirDown;
                row += isDirDown ? +1 : -1;
            }
        }

        private static void FillMatrixC(int[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1, index = 1; index <= matrix.GetLength(0) * matrix.GetLength(1); row--)
            {
                for (int currCol = (row >= 0 ? 0 : -row), currRow = (row >= 0 ? row : 0);
                currCol < (matrix.GetLength(1) - (row >= 0 ? row : 0));)
                {
                    matrix[currRow++, currCol++] = index++;
                }
            }
        }

        private static void FillMatrixD(int[,] matrix)
        {
            string direction = "down";
            int row = -1, col = 0;
            for (int index = 1; index <= matrix.GetLength(0) * matrix.GetLength(1); index++)
            {
                if (direction == "down")
                {
                    if (matrix[++row, col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row + 1, col)) direction = "right";
                }
                else if (direction == "right")
                {
                    if (matrix[row, ++col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row, col + 1)) direction = "up";
                }
                else if (direction == "up")
                {
                    if (matrix[--row, col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row - 1, col)) direction = "left";
                }
                else if (direction == "left")
                {
                    if (matrix[row, --col] == 0) matrix[row, col] = index;
                    if (!IsTraversable(matrix, row, col - 1)) direction = "down";
                }
            }
        }

        private static bool IsTraversable(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLongLength(0) &&
            col >= 0 && col < matrix.GetLongLength(1) && matrix[row, col] == 0;
        }

        private static void PrintMatrix(int[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++) 
                {
                    if (col == matrix.GetLength(0) - 1)
                    {
                        Console.Write("{0}", matrix[row, col]);
                    }
                    else
                    {
                        Console.Write("{0} ", matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

