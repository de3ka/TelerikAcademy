using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appearance_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string str = Console.ReadLine();
            string[] str1 = str.Split(' ');
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(str1[i]);
            }
            int x = int.Parse(Console.ReadLine());
            int result = CountPresence(arr, x);
            Console.WriteLine(result);

        }

        static int CountPresence(int[] array, int target)
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
