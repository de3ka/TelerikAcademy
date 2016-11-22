using System;
using System.Linq;

namespace Extensions_Delegates_Lambda_LINQ._06.Divisible_By_7_And_3
{
    public static class ArrayExtensions
    {
        public static void PrintDivisibleBy7And3(this int[] array)
        {
            var toPrint = array
                    .Where(x => x % 3 == 0 && x % 7 == 0)
                    .ToArray();

            foreach (var number in toPrint)
            {
                Console.WriteLine(number);
            }
        }
    }
}
