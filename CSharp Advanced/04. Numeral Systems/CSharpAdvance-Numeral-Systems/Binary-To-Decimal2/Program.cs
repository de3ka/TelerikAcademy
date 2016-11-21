using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02_ConvertBinaryToDecimal
{
    class ConvertBinaryToDecimal
    {
        static void Main()
        {
            string number = Console.ReadLine().TrimStart('0');
            long decNumber = 0;
            int index = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                decNumber += (long)(long.Parse(number[i].ToString()) * Math.Pow(2, index));
                index++;
            }

            Console.WriteLine(decNumber);
        }
    }
}
