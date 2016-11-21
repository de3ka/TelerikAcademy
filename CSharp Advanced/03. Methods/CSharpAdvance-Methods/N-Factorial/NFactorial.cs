using System;
using System.Collections.Generic;
using System.Text;

namespace N_Factorial
{
    public class NFactorial
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string factorial = Calculate(number);
            Console.WriteLine(factorial);
        }

        private static string Calculate(int n)
        {
            string finalResult = "1";

            for (int i = 2; i <= n; i++)
            {
                finalResult = Multiply(finalResult, i);
            }

            return finalResult;
        }

        private static string Multiply(string numberOne, int numberTwo)
        {
            List<int> digits = GetDigits(numberOne);

            StringBuilder sb = new StringBuilder();
            int number = 0;

            for (int index = 0; index < digits.Count; index++)
            {
                int digitResult = digits[index] * numberTwo;
                digitResult += number;

                if (digitResult < 10)
                {
                    sb.Insert(0, digitResult);
                    number = 0;
                }
                else if (digitResult >= 10)
                {
                    sb.Insert(0, digitResult % 10);
                    number = digitResult / 10;
                }
            }

            if (number > 0)
            {
                sb.Insert(0, number);
            }

            string endResult = Convert.ToString(sb);

            return endResult;
        }

        private static List<int> GetDigits(string number)
        {
            List<int> digits = new List<int>();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                digits.Add(int.Parse(Convert.ToString(number[i])));
            }

            return digits;
        }
    }
}