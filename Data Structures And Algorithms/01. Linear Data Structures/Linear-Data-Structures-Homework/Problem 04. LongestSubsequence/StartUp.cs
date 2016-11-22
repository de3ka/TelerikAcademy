using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_04.LongestSubsequence
{
    public class StartUp
    {
        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();
            var maxSubSequence = FindMaxSubSequence(sequence);

            Console.WriteLine("The maximal subsequence of equal numbers is:");
            Console.WriteLine(string.Join(",", maxSubSequence));
        }

        public static List<int> FindMaxSubSequence(List<int> sequence)
        {
            if (sequence.Count == 0)
            {
                return new List<int>();
            }

            var maxSubsequenceLength = 1;
            var maxSubSequenceNumber = sequence[0];
            var currentSubSequenceLength = 1;

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] == sequence[i - 1])
                {
                    currentSubSequenceLength++;
                }
                else
                {
                    if (currentSubSequenceLength > maxSubsequenceLength)
                    {
                        maxSubsequenceLength = currentSubSequenceLength;
                        maxSubSequenceNumber = sequence[i - 1];
                    }

                    currentSubSequenceLength = 1;
                }
            }

            return Enumerable.Repeat(maxSubSequenceNumber, maxSubsequenceLength).ToList();
        }
    }
}