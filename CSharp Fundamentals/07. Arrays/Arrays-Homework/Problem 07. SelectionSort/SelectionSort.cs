using System;

namespace Problem_07.SelectionSort
{
    public class SelectionSort
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < arr.Length; i++)
            {
                int maxElem = 0;
                for (int j = 0; j <= arr.Length - i; j++)
                {
                    if (arr[j] > arr[maxElem])
                    {
                        maxElem = j;
                    }
                    int temp = arr[maxElem];
                    arr[maxElem] = arr[arr.Length - i];
                    arr[arr.Length - i] = temp;
                }
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
