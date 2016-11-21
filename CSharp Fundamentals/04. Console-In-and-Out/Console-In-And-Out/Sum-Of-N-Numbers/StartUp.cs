using System;

namespace Sum_Of_N_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                double num = Convert.ToDouble(Console.ReadLine());
                sum = sum + num;
            }
            Console.WriteLine("{0}", sum);
        }
    }
}
