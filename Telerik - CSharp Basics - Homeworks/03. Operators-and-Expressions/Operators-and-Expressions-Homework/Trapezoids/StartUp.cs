using System;

namespace Trapezoids
{
    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            if (a >= -500 && a <= 500 || b >= -500 && b <= 500 || height >= -500 && height <= 500)
            {
                double area = ((a + b) / 2) * height;
                Console.WriteLine("{0:F7}", area);
            }
            else
            {

            }
        }
    }
}
