using System;

namespace Sorting_Array
{
    public class SortingArray
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            string str = Console.ReadLine();
            string[] str1 = str.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(str1[i]);
            }

            PerformSortArray(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write(arr[i]);
                }
                else
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }

        private static void PerformSortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
