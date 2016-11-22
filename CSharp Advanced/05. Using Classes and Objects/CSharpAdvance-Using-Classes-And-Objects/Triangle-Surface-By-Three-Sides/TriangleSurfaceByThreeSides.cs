using System;

namespace Triangle_Surface_By_Three_Sides
{
    public class TriangleSurfaceByThreeSides
    {
        public static void Main()
        {
            double firstSide = double.Parse(Console.ReadLine());
            double secondSide = double.Parse(Console.ReadLine());
            double thirdSide = double.Parse(Console.ReadLine());

            double halPerimeter = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(halPerimeter * (halPerimeter - firstSide) * (halPerimeter - secondSide) * (halPerimeter - thirdSide));
            Console.WriteLine("{0:F2}", area);
        }
    }
}
