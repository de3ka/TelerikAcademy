using System;

namespace Problem_13.Queue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            Console.WriteLine("Adding 1,2,3,4,5");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine("Peeking first added number: {0}", queue.Peek());
            Console.WriteLine("Dequeuing number: {0}", queue.Dequeue());
            Console.WriteLine("Dequeuing number: {0}", queue.Dequeue());
            Console.WriteLine("Peeking number: {0}", queue.Peek());

            Console.WriteLine("Enqueueing number 6");
            queue.Enqueue(6);

            Console.WriteLine("Peeking number: {0}", queue.Peek());
        }
    }
}