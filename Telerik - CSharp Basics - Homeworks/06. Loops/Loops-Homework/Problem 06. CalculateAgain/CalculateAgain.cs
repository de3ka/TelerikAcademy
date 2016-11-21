using System;
using System.Numerics;

namespace Problem_06.CalculateAgain
{
    public class CalculateAgain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            if (n > 1 && k > 1 && n < 100 && k < 100 && n > k)
            {
                BigInteger factorialN = 1;
                BigInteger factorialK = 1;
                BigInteger result = 0;
                for (int i = k + 1; i <= n; i++)
                {
                    factorialN *= i;
                }
                result = factorialN;
                Console.WriteLine(result);
            }
            else
            {
            }
        }
    }
}
