using System;
using System.Collections.Generic;

namespace Problem_10.ShortestSequenceOfOperations
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter starting number: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ending number: ");
            var m = int.Parse(Console.ReadLine());

            FindShortest(n, m);
        }

        private static void FindShortest(int start, int end)
        {
            if (start > end)
            {
                Console.WriteLine("The starting number is bigger or equal to the ending one");
            }

            var counter = 2;
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var number = queue.Dequeue();

            while (number != end)
            {
                queue.Enqueue(number + 1);
                queue.Enqueue(number + 2);
                queue.Enqueue(number * 2);

                number = queue.Dequeue();
                counter++;
            }

            var operationsStack = new Stack<int>();

            while (counter >= 3)
            {
                operationsStack.Push(counter % 3);
                counter = counter / 3 + 1;
            }

            var numberOfTheSequence = start;
            Console.Write("{0}", numberOfTheSequence);

            foreach (var operationNumber in operationsStack)
            {
                switch (operationNumber)
                {
                    case 0:
                        numberOfTheSequence += 1;
                        break;
                    case 1:
                        numberOfTheSequence += 2;
                        break;
                    case 2:
                        numberOfTheSequence *= 2;
                        break;
                }

                Console.Write("->{0}", numberOfTheSequence);
            }
        }
    }
}