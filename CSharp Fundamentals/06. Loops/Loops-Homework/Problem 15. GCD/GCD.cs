using System;

namespace Problem_15.GCD
{
    public class GCD
    {
        public static void Main()
        {
            string nums = Console.ReadLine();
            string[] n = nums.Split(' ');
            int a = Convert.ToInt32(n[0]);
            int b = Convert.ToInt32(n[1]);
            int remainder = 1;
            int quotient = 0;
            while (remainder != 0)
            {
                quotient = a / b;
                remainder = a % b;
                a = b;
                b = remainder;
            }

            Console.WriteLine("{0}", a);
        }
    }
}
