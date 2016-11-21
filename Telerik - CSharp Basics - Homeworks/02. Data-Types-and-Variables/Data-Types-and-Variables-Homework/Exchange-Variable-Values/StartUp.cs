using System;

namespace Exchange_Variable_Values
{
    public class StartUp
    {
        public static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("before the swap: ");
            Console.WriteLine("a={0}", a);
            Console.WriteLine("b={0}", b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("after the swap: ");
            Console.WriteLine("a={0}", a);
            Console.WriteLine("b={0}", b);
        }
    }
}
