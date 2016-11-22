using System;

namespace Problem_12.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            Console.WriteLine("Adding 1,2,3,4,5");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("Peeking last added number: {0}", stack.Peek());
            Console.WriteLine("Popping number: {0}", stack.Pop());
            Console.WriteLine("Popping number: {0}", stack.Pop());
            Console.WriteLine("Peeking number: {0}", stack.Peek());

            Console.WriteLine("Pushing number 6");
            stack.Push(6);

            Console.WriteLine("Peeking number: {0}", stack.Peek());
        }
    }
}