using System;

namespace Problem_15.PrimeNumbers
{
    public class PrimeNumbers
    {
        public static void Main()
        {

            int inputNumber = int.Parse(Console.ReadLine());
            bool[] arr = new bool[inputNumber + 1];

            for (int i = 2; i * i <= arr.Length; i++)
            {
                if (!arr[i])
                {
                    for (int j = i * i; j < arr.Length; j += i)
                    {
                        arr[j] = true;
                    }
                }
            }

            int biggest = 0;

            for (int i = 2; i < arr.Length; i++)
            {
                if (!arr[i])
                {
                    biggest = i;
                }
            }

            Console.WriteLine(biggest);
        }
    }
}