using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _07_FromBaseSToBaseD
{
    class FromBaseSToBaseD
    {
        static long ConvertToDec(string number, int baseFrom)
        {
            long decNum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] > '9')
                {
                    decNum += (number[i] - '7') * (long)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
                else
                {
                    decNum += (number[i] - '0') * (long)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
            }
            return decNum;
        }
        static void ConvertFromDec(long number, int baseTo)
        {
            List<long> result = new List<long>();
            if (baseTo > 10)
            {
                while (number > 0)
                {
                    result.Add(number % baseTo);
                    number = number / baseTo;
                }
                result.Reverse();
                foreach (var item in result)
                {
                    switch (item)
                    {
                        case 10: Console.Write("A");
                            break;
                        case 11: Console.Write("B");
                            break;
                        case 12: Console.Write("C");
                            break;
                        case 13: Console.Write("D");
                            break;
                        case 14: Console.Write("E");
                            break;
                        case 15: Console.Write("F");
                            break;
                        default: Console.Write(item);
                            break;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                while (number > 0)
                {
                    result.Add(number % baseTo);
                    number = number / baseTo;
                }
                result.Reverse();
                foreach (var item in result)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            string number = (Console.ReadLine()).TrimStart('0').ToUpper();
            int s = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            if (s < 2 || d < 2 || s > 16 || d > 16)
            {
                Console.WriteLine("The numeral systems must be in the range [2 .. 16]");
            }
            else
            {
                ConvertFromDec(ConvertToDec(number, s), d);
            }
        }
    }
}