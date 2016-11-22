using Common;
using System;

namespace Problem_08.Pathfinder2
{
    public class StartUp
    {
        public static void Main()
        {
            var matrix = new string[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix[i, j] = "0";
                }
            }

            var start = new Position(2, 1);
            var end = new Position(88, 93);

            if (!Pathfinder.Find(start, end, matrix))
            {
                Console.WriteLine("A path is not found");
            }
        }
    }
}