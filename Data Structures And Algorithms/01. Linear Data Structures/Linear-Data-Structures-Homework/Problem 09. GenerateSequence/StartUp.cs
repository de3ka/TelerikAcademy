using System;
using System.Collections.Generic;

namespace Problem_09.GenerateSequence
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Insert a number: ");
            var n = int.Parse(Console.ReadLine());

            var sequence = GenerateSequence(n, 50);

            Console.WriteLine("The generated sequence is:");
            Console.WriteLine(string.Join(",", sequence));
        }

        private static List<int> GenerateSequence(int n, int count)
        {
            var queue = new Queue<int>();
            queue.Enqueue(n);

            var sequence = new List<int>();
            sequence.Add(n);

            for (int i = 1; i < count; i++)
            {
                var number = 0;

                if (i % 3 == 1)
                {
                    number = queue.Peek() + 1;
                }
                else if (i % 3 == 2)
                {
                    number = queue.Peek() * 2 + 1;
                }
                else
                {
                    number = queue.Dequeue() + 2;
                }


                sequence.Add(number);
                queue.Enqueue(number);
            }

            return sequence;
        }
    }
}