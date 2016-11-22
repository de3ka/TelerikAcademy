using WalkInMatrix.Contracts;
using WalkInMatrix.Enums;
using WalkInMatrix.GlobalConstants;
using WalkInMatrix.Models;

namespace WalkInMatrix.Utils
{
    public static class MatrixGenerator
    {
        public static Matrix Generate(int matrixSize)
        {
            var matrix = new Matrix(matrixSize, matrixSize);
            int stepCount = 0;
            IPosition position = Globals.defaultPosition;

            while (position != null)
            {
                stepCount++;
                matrix[position] = stepCount;
                var direction = Globals.defaultDirection;

                while (matrix.CheckIfAnyNeighbourCellContainsValue(position, 0))
                {
                    IPosition newPosition = position.getNeighbourPosition(direction);

                    while (!matrix.IsPositionValid(newPosition) || matrix[newPosition] != 0)
                    {
                        direction = GetNextDirection(direction);
                        newPosition = position.getNeighbourPosition(direction);
                    }

                    position = newPosition;
                    stepCount++;
                    matrix[position] = stepCount;
                }

                position = matrix.FindFirstCellPositionWithValue(0);
            }

            return matrix;
        }

        public static DirectionType GetNextDirection(DirectionType currentDirection)
        {
            var directionIndex = Globals.directionsOrderClockwise.IndexOf(currentDirection);
            directionIndex++;
            if (directionIndex >= Globals.directionsOrderClockwise.Count)
            {
                directionIndex = 0;
            }

            return Globals.directionsOrderClockwise[directionIndex];
        }
    }
}
