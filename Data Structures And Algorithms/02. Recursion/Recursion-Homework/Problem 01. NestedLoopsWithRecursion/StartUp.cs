using System;

namespace Problem_01.NestedLoopsWithRecursion
{
    public class StartUp
    {
        public static void Main()
        {
            SimulateLoops(3, 3, new int[3]);
        }

        private static void SimulateLoops(int iterations, int depthLevel, int[] values)
        {
            if (depthLevel == 0)
            {
                PrintValues(values);
                return;
            }

            for (int i = 1; i <= iterations; i++)
            {
                values[depthLevel - 1] = i;
                SimulateLoops(iterations, depthLevel - 1, values);
            }
        }

        private static void PrintValues(int[] values)
        {
            Console.WriteLine(string.Join(" ", values));
        }
    }
}