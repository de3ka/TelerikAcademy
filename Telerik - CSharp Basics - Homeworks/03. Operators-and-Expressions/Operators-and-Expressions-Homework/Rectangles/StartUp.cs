using System;

namespace Rectangles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double perimeter = 2 * (width + height);
            double area = width * height;
            Console.WriteLine("{0:F2} {1:F2}", area, perimeter);
        }
    }
}
