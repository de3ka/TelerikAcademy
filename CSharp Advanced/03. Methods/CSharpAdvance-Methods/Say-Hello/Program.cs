﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Say_Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            SayHello(name);
        }

        static void SayHello(string name) {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
