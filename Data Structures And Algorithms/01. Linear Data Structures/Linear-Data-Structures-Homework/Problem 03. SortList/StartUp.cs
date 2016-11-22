using Common;
using System;

namespace Problem_03.SortList
{
    public class StartUp
    {
        static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] > sequence[j])
                    {
                        sequence[i] ^= sequence[j];
                        sequence[j] ^= sequence[i];
                        sequence[i] ^= sequence[j];
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, sequence));
        }
    }
}
