using System;
using System.Collections.Generic;

namespace Problem_08.FindMajorant
{
    public class StartUp
    {
        public static void Main()
        {
            int[] array = new int[9] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            FindMajorant(array);
        }

        private static void FindMajorant(int[] array)
        {
            var numbers = new Dictionary<int, int>();

            foreach (var number in array)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            foreach (var pair in numbers)
            {
                if (pair.Value >= array.Length / 2 + 1)
                {
                    Console.WriteLine("The majorant is {0}", pair.Key);
                    return;
                }
            }

            Console.WriteLine("There is no majorant");
        }
    }
}