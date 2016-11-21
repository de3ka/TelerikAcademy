using System;

namespace Problem_05.Calculate
{
    public class Calculate
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            int factorial = 1;
            double sum = 1 + 1 / x;
            for (int counter = 2; counter <= n; counter++)
            {
                factorial = factorial * counter;
                double pow = Math.Pow(x, counter);
                sum = sum + (factorial / pow);
            }

            Console.WriteLine("{0:F5}", sum);
        }
    }
}
