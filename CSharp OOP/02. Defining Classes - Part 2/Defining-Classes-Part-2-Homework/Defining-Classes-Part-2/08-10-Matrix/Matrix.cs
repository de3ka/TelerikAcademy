using System;

namespace Defining_Classes_Part_2._08_10_Matrix
{
    public class Matrix<T> where T : IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Columns = cols;
            matrix = new T[this.Rows, this.Columns];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows cannot be less than 0!");
                }
                else
                {
                    this.rows = value;
                }
            }
        }

        public int Columns
        {
            get
            {
                return this.cols;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Columns cannot be less than 0!");
                }
                else
                {
                    this.cols = value;
                }
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row > this.Rows)
                {
                    throw new IndexOutOfRangeException(string.Format("Rows must be between 0 and {0}!", this.Rows - 1));
                }
                else if (col < 0 || col > this.Columns)
                {
                    throw new IndexOutOfRangeException(string.Format("Cols must be between 0 and {0}!", this.Columns - 1));
                }
                else
                {
                    return this.matrix[row, col];
                }
            }

            set
            {
                if (row < 0 || row > this.Rows)
                {
                    throw new IndexOutOfRangeException(string.Format("Rows must be between 0 and {0}!", this.Rows - 1));
                }
                else if (col < 0 || col > this.Columns)
                {
                    throw new IndexOutOfRangeException(string.Format("Cols must be between 0 and {0}!", this.Columns - 1));
                }
                else
                {
                    this.matrix[row, col] = value;
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(0) ||
                firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(1))
            {
                throw new ArgumentException("The two matrixes must have same size!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);

            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Columns; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(0) ||
                firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(1))
            {
                throw new ArgumentException("The two matrixes must have same size!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Columns);

            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < firstMatrix.Columns; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(0))
            {
                throw new ArgumentException("The two matrices must have same dimensions!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Rows);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Columns; col++)
                {
                    for (int i = 0; i < resultMatrix.Columns; i++)
                    {
                        resultMatrix[row, col] += (dynamic)firstMatrix[row, i] * (dynamic)secondMatrix[i, col];
                    }
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool isTrue = true;

            for (int row = 0; row < matrix.matrix.GetLength(0) && isTrue; row++)
            {
                for (int col = 0; col < matrix.matrix.GetLength(1) && isTrue; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        isTrue = false;
                    }
                }
            }

            return isTrue;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool isTrue = true;

            for (int row = 0; row < matrix.matrix.GetLength(0) && isTrue; row++)
            {
                for (int col = 0; col < matrix.matrix.GetLength(1) && isTrue; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        isTrue = false;
                    }
                }
            }

            return !isTrue;
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    result += this.matrix[row, col];
                    if (col < this.Columns - 1)
                    {
                        result += " ";
                    }
                }
                result += "\n";
            }

            return result;
        }
    }
}