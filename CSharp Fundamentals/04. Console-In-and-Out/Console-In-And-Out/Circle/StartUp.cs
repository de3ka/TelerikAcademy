using System;

namespace Circle
{
    public class StartUp
    {
        public static void Main()
        {
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2} {1:F2}", (2 * Math.PI * radius), Math.PI * Math.Pow(radius, 2));
        }
    }
}
