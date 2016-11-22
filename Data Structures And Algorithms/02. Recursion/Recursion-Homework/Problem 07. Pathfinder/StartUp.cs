using Common;

namespace Problem_07.Pathfinder
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

            var start = new Position(2, 1);
            var end = new Position(2, 3);

            Pathfinder.Find(start, end, matrix);
        }
    }
}