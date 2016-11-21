using System;
using System.Numerics;

namespace Integer_Calculations
{
    public class IntegerCalculations
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] numbersCharArr = input.Split(' ');

            int[] numbers = new int[numbersCharArr.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Int32.Parse(numbersCharArr[i]);
            }

            int max = ReturnMax(numbers);

            BigInteger min = ReturnMin(numbers);
            double average = ReturnAverage(numbers);
            BigInteger sum = ReturnSum(numbers);
            BigInteger product = ReturnProduct(numbers);

            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine("{0:F2}", average);
            Console.WriteLine(sum);
            Console.WriteLine(product);
        }

        private static int ReturnMax(int[] arr)
        {
            Array.Sort(arr);

            return arr[0];
        }

        private static int ReturnMin(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);

            return arr[0];
        }

        private static double ReturnAverage(int[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            double average = sum / arr.Length;

            return average;
        }

        private static int ReturnSum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        private static BigInteger ReturnProduct(int[] arr)
        {
            BigInteger product = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }

            return product;
        }
    }
}