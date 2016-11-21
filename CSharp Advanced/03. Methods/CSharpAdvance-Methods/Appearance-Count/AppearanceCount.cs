using System;

namespace Appearance_Count
{
    public class AppearanceCount
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] splittedString = str.Split(' ');

            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(splittedString[i]);
            }

            int x = int.Parse(Console.ReadLine());

            int result = CountPresence(arr, x);
            Console.WriteLine(result);

        }

        private static int CountPresence(int[] array, int target)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    count++;
                }
            }

            return count;
        }
    }
}