using System;

namespace Moon_Gravity
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            if (weight > 0 || weight < 1000)
            {
                Console.WriteLine("{0:F3}", ((17 * weight) / 100));
            }
            else
            {

            }
        }
    }
}

