using System;

namespace Get_Largest_Number
{
    public class GetLargestNumber
    {
        public static void Main()
        {
            string nums = Console.ReadLine();
            string[] numbers = nums.Split(' ');
            int[] num = new int[numbers.Length];

            for (int i = 0; i < num.Length; i++)
            {
                num[i] = Int32.Parse(numbers[i]);
            }

            Console.WriteLine(ReturnMax(ReturnMax(num[0], num[1]), num[2]));
        }

        private static int ReturnMax(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}