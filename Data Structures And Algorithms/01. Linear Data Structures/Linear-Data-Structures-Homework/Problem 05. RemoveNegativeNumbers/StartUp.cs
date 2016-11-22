using Common;
using System;
using System.Collections.Generic;

namespace Problem_05.RemoveNegativeNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sequence = ConsoleReader.ReadSequence();

            var outputValues = new LinkedList<int>();
            foreach (var value in sequence)
            {
                if (0 <= value)
                {
                    outputValues.AddLast(value);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, outputValues));
        }
    }
}
