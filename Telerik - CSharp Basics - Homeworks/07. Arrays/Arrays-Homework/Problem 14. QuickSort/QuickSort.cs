using System;

namespace Problem_14.QuickSort
{
    public class QuickSort
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            PerformQuickSort(arr, 0, arr.Length - 1);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int k = left - 1;
            for (int index = left; index <= right; index++)
            {
                if (arr[index] <= pivot)
                {
                    k++;
                    Swap(arr, k, index);
                }
            }
            return k;
        }

        private static void PerformQuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int k = Partition(arr, left, right);
            PerformQuickSort(arr, left, k - 1);
            PerformQuickSort(arr, k + 1, right);
        }
    }
}