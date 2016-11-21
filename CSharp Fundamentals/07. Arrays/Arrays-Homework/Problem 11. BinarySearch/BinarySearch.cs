using System;

namespace Problem_11.BinarySearch
{
    public class BinarySearch
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }

            int x = int.Parse(Console.ReadLine());
            int index = PerformBinarySearch(arr, x, 0, arr.Length - 1);
            Console.WriteLine(index);

        }
        private static int PerformBinarySearch(int[] arr, int x, int start, int end)
        {
            int mid = (end + start) / 2;
            if (start > end)
            {
                return -1;
            }
            if (x == arr[mid])
            {
                return mid;
            }
            else
                if (x < arr[mid])
            {
                return PerformBinarySearch(arr, x, start, mid - 1);
            }
            else
                    if (x > arr[mid])
            {
                return PerformBinarySearch(arr, x, mid + 1, end);
            }

            return -1;
        }
    }
}
