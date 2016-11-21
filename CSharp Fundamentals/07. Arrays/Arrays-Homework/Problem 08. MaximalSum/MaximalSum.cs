using System;

namespace Problem_08.MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxSum = 0;
            int tempSum = 0;
            maxSum = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                tempSum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    tempSum += arr[j];
                    if (tempSum > maxSum)
                        maxSum = tempSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
