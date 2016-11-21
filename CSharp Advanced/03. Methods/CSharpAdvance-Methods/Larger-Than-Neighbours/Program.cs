using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larger_Than_Neighbours
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
            int result = CheckIfBigger(arr);
            Console.WriteLine(result);
            
        }
        static int CheckIfBigger(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i+2==array.Length-1)
                {
                    break; 
                }
                if (array[i+1]>array[i] && array[i+1]>array[i+2])
                {
                    count++;
                }
            }
            return count;
            
        }
    }
}
