using System.Collections.Generic;
using WalkInMatrix.Enums;
using WalkInMatrix.Models;

namespace WalkInMatrix.GlobalConstants
{
    internal static class Globals
    {
        internal static readonly Position defaultPosition = new Position(0, 0);
        internal static readonly DirectionType defaultDirection = DirectionType.DownRight;
        internal static readonly IList<DirectionType> directionsOrderClockwise = new DirectionType[] {
            DirectionType.DownRight,
            DirectionType.Down,
            DirectionType.DownLeft,
            DirectionType.Left,
            DirectionType.UpLeft,
            DirectionType.Up,
            DirectionType.UpRight,
            DirectionType.Right
        };
    }
}
