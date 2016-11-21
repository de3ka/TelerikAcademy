using System;

namespace Problem_09.FrequentNumber
{
    public class FrequentNumber
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int count = 1, tempCount;
            int popular = arr[0];
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    break;
                }
                temp = arr[i];
                tempCount = 0;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (temp == arr[j])
                        tempCount++;
                }
                if (tempCount > count)
                {
                    popular = temp;
                    count = tempCount;
                }
            }

            Console.WriteLine("{0} ({1} times)", popular, count);
        }
    }
}
