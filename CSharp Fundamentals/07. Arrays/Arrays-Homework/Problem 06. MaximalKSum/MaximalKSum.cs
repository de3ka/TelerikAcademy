using System;

namespace Problem_06.MaximalKSum
{
    public class MaximalKSum
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            int maxSum = 0;
            for (int i = 0; i < k; i++)
            {
                maxSum += arr[i];
            }

            Console.WriteLine(maxSum);
        }
    }
}
