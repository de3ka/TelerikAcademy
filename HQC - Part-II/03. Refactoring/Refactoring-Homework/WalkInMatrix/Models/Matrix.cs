using WalkInMatrix.Contracts;

namespace WalkInMatrix.Models
{
    public class Matrix
    {
        private int[,] matrixArray;

        public Matrix(int rowsLen, int colsLen)
        {
            this.MatrixArray = new int[rowsLen, colsLen];
        }
        public int[,] MatrixArray
        {
            get { return matrixArray; }
            set { matrixArray = value; }
        }

        public int this[IPosition position]
        {
            get
            {
                return this.matrixArray[position.Row, position.Col];
            }
            set
            {
                this.matrixArray[position.Row, position.Col] = value;
            }
        }

        public int GetLength(int dimension)
        {
            return this.MatrixArray.GetLength(dimension);
        }
    }
}
