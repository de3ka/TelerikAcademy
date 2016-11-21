using System;

namespace Problem_06.TheBiggestОfFiveNumbers
{
    public class TheBiggestОfFiveNumbers
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            double max;
            if (a >= b && a >= c && a >= d && a >= e)
            {
                max = a;
            }
            else if (b >= a && b >= c && b >= d && b >= e)
            {
                max = b;
            }
            else if (c >= a && c >= b && c >= d && c >= e)
            {
                max = c;
            }
            else if (d >= a && d >= b && d >= c && d >= e)
            {
                max = d;
            }
            else
            {
                max = e;
            }
            Console.WriteLine("{0}", max);
        }
    }
}
