using System;

namespace Point_In_A_Circle
{
    public class StartUp
    {
        public static void Main()
        {
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());

            if ((Math.Sqrt((x * x) + (y * y))) <= 2)
            {
                Console.WriteLine("yes {0:F2}", Math.Abs(0 - (Math.Sqrt((x * x) + (y * y)))));
            }
            else
            {
                Console.WriteLine("no {0:F2}", Math.Abs(0 - (Math.Sqrt((x * x) + (y * y)))));
            }
        }
    }
}
