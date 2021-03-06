﻿using System;

namespace English_Digit
{
    public class EnglishDigit
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            string str = ReturnLastDigitAsString(num);
            Console.WriteLine(str);
        }

        private static string ReturnLastDigitAsString(int num)
        {
            int lastDigit = num % 10;
            string result = "";

            switch (lastDigit)
            {
                case 0:
                    result += "zero";
                    break;
                case 1:
                    result += "one";
                    break;
                case 2:
                    result += "two";
                    break;
                case 3:
                    result += "three";
                    break;
                case 4:
                    result += "four";
                    break;
                case 5:
                    result += "five";
                    break;
                case 6:
                    result += "six";
                    break;
                case 7:
                    result += "seven";
                    break;
                case 8:
                    result += "eight";
                    break;
                case 9:
                    result += "nine";
                    break;
            }

            return result;
        }
    }
}