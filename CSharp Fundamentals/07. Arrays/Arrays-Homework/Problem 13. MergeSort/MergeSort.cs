using System;

namespace Problem_13.MergeSort
{
    public class MergeSort
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int[] temp = new int[arr.Length];
            PerformMergeSort(arr, temp, 0, arr.Length - 1);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        private static void Merge(int[] arr, int[] tempArr, int firstNum, int secondNum, int thirdNum)
        {
            int i = firstNum;
            int j = secondNum + 1;
            int k = firstNum;

            while (i <= secondNum && j <= thirdNum)
            {
                if (arr[i] < arr[j])
                {
                    tempArr[k++] = arr[i++];
                }
                else
                {
                    tempArr[k++] = arr[j++];
                }
            }

            while (i <= secondNum)
            {
                tempArr[k++] = arr[i++];
            }
            while (j <= thirdNum)
            {
                tempArr[k++] = arr[j++];
            }

            for (i = firstNum; i <= thirdNum; i++)
            {
                arr[i] = tempArr[i];
            }
        }

        private static void PerformMergeSort(int[] arr, int[] tempArr, int firstNum, int secondNum)
        {
            if (firstNum >= secondNum)
            {
                return;
            }

            int m = firstNum + (secondNum - firstNum) / 2;

            PerformMergeSort(arr, tempArr, firstNum, m);
            PerformMergeSort(arr, tempArr, m + 1, secondNum);

            Merge(arr, tempArr, firstNum, m, secondNum);
        }
    }
}
