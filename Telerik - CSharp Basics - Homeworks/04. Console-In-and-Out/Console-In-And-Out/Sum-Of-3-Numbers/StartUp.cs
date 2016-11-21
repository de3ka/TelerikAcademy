using System;

namespace Sum_Of_3_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("{0}", a + b + c);
        }
    }
}
