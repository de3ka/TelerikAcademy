using System;

namespace Problem_09.MatrixOfNumbers
{
    public class MatrixOfNumbers
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int columN = 1;
            if (n < 1 || n > 20)
            {
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < n + i; j++)
                {
                    if (columN <= n)
                    {
                        Console.Write(j + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
