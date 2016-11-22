using System;
using WalkInMatrix.Contracts;
using WalkInMatrix.Enums;

namespace WalkInMatrix.Models
{
    public class Position : IPosition
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public IPosition getNeighbourPosition(DirectionType dir)
        {
            IPosition newPosition = new Position(this.Row, this.Col);

            switch (dir)
            {
                case DirectionType.DownRight:
                    newPosition.Row++;
                    newPosition.Col++;
                    break;
                case DirectionType.Down:
                    newPosition.Row++;
                    break;
                case DirectionType.DownLeft:
                    newPosition.Row++;
                    newPosition.Col--;
                    break;
                case DirectionType.Left:
                    newPosition.Col--;
                    break;
                case DirectionType.UpLeft:
                    newPosition.Row--;
                    newPosition.Col--;
                    break;
                case DirectionType.Up:
                    newPosition.Row--;
                    break;
                case DirectionType.UpRight:
                    newPosition.Row--;
                    newPosition.Col++;
                    break;
                case DirectionType.Right:
                    newPosition.Col++;
                    break;
                default:
                    throw new ArgumentException("Invalid direction.");
            }

            return newPosition;
        }
    }
}
