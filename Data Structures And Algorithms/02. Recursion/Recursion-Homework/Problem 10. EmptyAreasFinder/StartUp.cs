using System;

namespace Problem_10.EmptyAreasFinder
{
    public class StartUp
    {
        public static void Main()
        {
            string[,] matrix = new string[6, 6]
                {
                    { "0", "0", "0", "x", "0", "x"},
                    { "0", "x", "0", "x", "0", "x"},
                    { "0", "0", "x", "0", "x", "0"},
                    { "0", "x", "0", "0", "0", "0"},
                    { "0", "0", "0", "x", "x", "0"},
                    { "0", "0", "0", "x", "0", "x"},
                };

            var areas = AreasFinder.FindAllAreas(matrix);

            Console.WriteLine("The number of areas in the matrix is {0}", areas.Count);
            foreach (var area in areas)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("{0}", string.Join(" ", area));
            }
        }
    }
}