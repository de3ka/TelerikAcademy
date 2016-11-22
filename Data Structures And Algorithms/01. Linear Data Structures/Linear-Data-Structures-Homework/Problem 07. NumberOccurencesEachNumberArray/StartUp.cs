using System;
using System.Collections.Generic;

namespace Problem_07.NumberOccurencesEachNumberArray
{
    public class StartUp
    {
        public static void Main()
        {
            int[] array = new int[9] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            ShowOccurences(array);
        }

        private static void ShowOccurences(int[] array)
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
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}