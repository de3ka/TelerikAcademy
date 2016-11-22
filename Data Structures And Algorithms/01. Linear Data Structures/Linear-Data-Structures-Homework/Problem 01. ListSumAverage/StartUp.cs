using System;
using System.Collections.Generic;
using Common;

namespace Problem_01.ListSumAverage
{
    public class StartUp
    {
        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();

            Console.WriteLine("The sum of the sequence is {0}", FindSum(sequence));
            Console.WriteLine("The average of the sequence is {0}", FindAverage(sequence));
        }

        private static int FindSum(List<int> sequence)
        {
            int sum = 0;

            foreach (var value in sequence)
            {
                try
                {
                    sum += value;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Overflow at {sum}");
                }
            }

            return sum;
        }

        private static int FindAverage(List<int> sequence)
        {
            int sum = FindSum(sequence);

            return sum / sequence.Count;
        }
    }
}