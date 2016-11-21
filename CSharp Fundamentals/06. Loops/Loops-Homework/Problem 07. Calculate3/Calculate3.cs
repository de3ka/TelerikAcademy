using System;
using System.Numerics;

namespace Problem_07.Calculate3
{
    public class Calculate3
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = k + 1; i <= n; i++)
            {
                result *= i;
            }

            BigInteger divisor = 1;

            for (int i = 1; i <= n - k; i++)
            {
                divisor *= i;
            }

            result /= divisor;

            Console.WriteLine("{0}", result);
        }
    }
}
