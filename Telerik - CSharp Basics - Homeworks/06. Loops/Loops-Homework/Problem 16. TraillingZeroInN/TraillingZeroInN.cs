using System;

namespace Problem_16.TraillingZeroInN
{
    public class TraillingZeroInN
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int zeroCount = 0;
            int temp;
            for (int i = 5; i <= number; i += 5)
            {
                temp = i;
                while (temp % 5 == 0)
                {
                    temp /= 5;
                    zeroCount++;
                }
            }

            Console.WriteLine(zeroCount);
        }
    }
}
