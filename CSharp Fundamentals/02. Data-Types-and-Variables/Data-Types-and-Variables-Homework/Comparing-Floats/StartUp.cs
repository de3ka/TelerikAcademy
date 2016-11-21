using System;

namespace Comparing_Floats
{
    public class StartUp
    {
        public static void Main()
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            //bool compare = true;
            if (Math.Abs(n1 - n2) < eps)
            {
                Console.WriteLine("true");
            }
            else if (Math.Abs(n1 - n2) >= eps)
            {
                Console.WriteLine("false");
            }
        }
    }
}
