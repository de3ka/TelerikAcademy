﻿using System;

namespace Problem_01.ExchangeIfGreater
{
    public class ExchangeIfGreater
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a > b)
            {
                Console.WriteLine("{0} {1}", b, a);
            }
            else
            {
                Console.WriteLine("{0} {1}", a, b);
            }
        }
    }
}
