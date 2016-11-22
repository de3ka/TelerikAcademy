using System.Collections.Generic;
using Common;
using Problem_09.EmptyCellFinder;

namespace Problem_10.EmptyAreasFinder
{
    public class AreasFinder : AreaFinder
    {
        public static List<List<Position>> FindAllAreas(string[,] matrix)
        {
            var areas = new List<List<Position>>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        var area = FindArea(new Position(i, j), matrix);
                        areas.Add(area);
                    }
                }
            }

            return areas;
        }
    }
}