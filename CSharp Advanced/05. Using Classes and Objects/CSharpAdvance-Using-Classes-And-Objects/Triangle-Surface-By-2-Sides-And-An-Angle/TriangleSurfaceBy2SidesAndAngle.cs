using System;

namespace Triangle_Surface_By_2_Sides_And_An_Angle
{
    public class TriangleSurfaceBy2SidesAndAngle
    {
        public static void Main()
        {
            Console.WriteLine
                (
                    (double.Parse(Console.ReadLine()) *
                     double.Parse(Console.ReadLine()) *
                     (Math.Sin(double.Parse(Console.ReadLine()) * Math.PI / 180) / 2)).ToString("F2")
                );
        }
    }
}