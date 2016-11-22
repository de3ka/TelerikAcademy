using System;

namespace Triangle_Surface_By_Side_And_Altitude
{
    public class TriangleSurfaceBySideAndAltitude
    {
        public static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());
            double result = (side * altitude) / 2;
            Console.WriteLine("{0:F2}", result);
        }
    }
}
