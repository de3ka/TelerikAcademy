using System;

namespace Sum_Of_5_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            double sum = a + b + c + d + e;
            Console.WriteLine("{0}", sum);
        }
    }
}
