using System;

namespace Problem_01.NumbersFrom1ToN
{
    public class NumbersFrom1ToN
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
