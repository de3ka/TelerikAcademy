using System;

namespace Problem_05.TheBiggestOf3Numbers
{
    public class TheBiggestOf3Numbers
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a >= b && a >= c)
            {
                Console.WriteLine("{0}", a);
            }
            else if (b >= a && b >= c)
            {
                Console.WriteLine("{0}", b);
            }
            else if (c >= a && c >= b)
            {
                Console.WriteLine("{0}", c);
            }
        }
    }
}
