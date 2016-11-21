using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Integer_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            string[] numbers = nums.Split(' ');
            int[] num = new int[numbers.Length];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = Int32.Parse(numbers[i]);
            }
            int max = returnMax(num);
            BigInteger min = returnMin(num);
            double average = returnAverage(num);
            BigInteger sum = returnSum(num);
            BigInteger product = returnProduct(num);
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine("{0:F2}",average);
            Console.WriteLine(sum);
            Console.WriteLine(product);


        }
        static int returnMax(int[] arr)
        {
            Array.Sort(arr);
            return arr[0];
        }

        static int returnMin(int[] arr) {
            Array.Sort(arr);
            Array.Reverse(arr);
            return arr[0];
        }
        static double returnAverage(int[] arr){
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            double average = sum / arr.Length;
            return average;
        }
        static int returnSum(int[] arr) {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static BigInteger returnProduct(int[] arr) {
            BigInteger product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }
    }
}
