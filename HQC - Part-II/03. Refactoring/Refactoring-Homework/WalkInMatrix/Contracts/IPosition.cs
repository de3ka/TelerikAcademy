using WalkInMatrix.Enums;

namespace WalkInMatrix.Contracts
{
    public interface IPosition
    {
        int Row { get; set; }
        int Col { get; set; }
        IPosition getNeighbourPosition(DirectionType direction);
    }
}
