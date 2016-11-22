using System;

namespace Random_Numbers
{
    public class RandomNumbers
    {
        public static void Main()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(100, 200));
            }
        }
    }
}
