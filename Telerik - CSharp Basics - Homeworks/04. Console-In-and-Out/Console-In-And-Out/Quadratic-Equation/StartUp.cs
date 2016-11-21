using System;

namespace Quadratic_Equation
{
    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double x1, x2, discriminant;
            discriminant = Math.Pow(b, 2) - (4 * a * c);
            if (discriminant > 0)
            {
                x1 = (((-1) * b) - Math.Sqrt(discriminant)) / (2 * a);
                x2 = (((-1) * b) + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("{0:F2}\n{1:F2}", x1, x2);
            }
            else if (discriminant == 0)
            {
                x1 = ((-1) * b) / (2 * a);
                Console.WriteLine("{0:F2}", x1);
            }
            else
            {
                Console.WriteLine("no real roots");
            }
        }
    }
}
