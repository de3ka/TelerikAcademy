using System;
using System.Numerics;

namespace Problem_08.CatalanNumbers
{
    public class CatalanNumbers
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger numerator = 1;
            BigInteger denominator = 1;

            for (int k = 2; k <= n; k++)
            {
                numerator *= n + k;
                denominator *= k;
            }
            BigInteger catalanNumber = numerator / denominator;

            Console.WriteLine("{0}", catalanNumber);
        }
    }
}