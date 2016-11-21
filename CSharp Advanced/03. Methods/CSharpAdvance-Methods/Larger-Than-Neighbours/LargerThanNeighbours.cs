using System;

namespace Larger_Than_Neighbours
{
    public class LargerThanNeighbours
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            string str = Console.ReadLine();
            string[] splittedStringArr = str.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(splittedStringArr[i]);
            }

            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (IsLargerThanNeighbors(arr, i))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static bool IsLargerThanNeighbors(int[] nums, int i)
        {
            bool isLarger = false;

            if (i == 0)
            {
                isLarger = false;
            }
            else if (i > 0 && i < nums.Length - 1)
            {
                isLarger = nums[i - 1] < nums[i] && nums[i + 1] < nums[i];
            }
            else
            {
                isLarger = false;
            }

            return isLarger;
        }
    }
}