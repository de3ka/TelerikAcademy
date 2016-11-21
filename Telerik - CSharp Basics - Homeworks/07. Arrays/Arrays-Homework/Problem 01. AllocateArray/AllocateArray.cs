using System;

namespace Problem_01.AllocateArray
{
    public class AllocateArray
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
