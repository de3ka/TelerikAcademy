//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int firstNumeralSystem = int.Parse(Console.ReadLine());
        long input = Math.Abs(long.Parse(Console.ReadLine()));
        int secondNumeralSystem = int.Parse(Console.ReadLine());

        long number = input;
        long decimalNumber = 0;
        int power = 0;
        while (number > 0)
        {
            int digit = (int)number % 10;
            digit *= (int)Math.Pow(firstNumeralSystem, (double)power);
            decimalNumber += digit;
            power++;
            number /= 10;
        }
        StringBuilder str = new StringBuilder();

        while (decimalNumber > 0)
        {
            str.Insert(0, decimalNumber % secondNumeralSystem);

            decimalNumber /= secondNumeralSystem;
        }
        Console.WriteLine(str.ToString());
    }
}