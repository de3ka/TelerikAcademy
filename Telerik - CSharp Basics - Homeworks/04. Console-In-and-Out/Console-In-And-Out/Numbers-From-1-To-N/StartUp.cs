using System;

namespace Numbers_From_1_To_N
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
