using WalkInMatrix.IOProviders;
using WalkInMatrix.Models;
using WalkInMatrix.Utils;

namespace WalkInMatrix
{
    public class MatrixStartUp
    {
        public static void Main()
        {
            int matrixLength = ConsoleInput.GetInput();
            Matrix matrix = MatrixGenerator.Generate(matrixLength);
            ConsoleOutput.PrintMatrix(matrix);
        }
    }
}