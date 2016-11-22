using System;

namespace Defining_Classes_Part_2._01_04_Structure
{
    public static class CalculateDistanceBetween2Points
    {
        public static double DistansBetweenTowPoints(Point3D a, Point3D b)
        {
            double diatance = Math.Sqrt(
               ((a.X - b.X) * (a.X - b.X)) +
               ((a.Y - b.Y) * (a.Y - b.Y)) +
              ((a.Z - b.Z) * (a.Z - b.Z)));

            return diatance;
        }
    }
}
