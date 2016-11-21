﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Larger_Than_Numbers
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
            int index = CheckArray(arr);
            Console.WriteLine(index);
        }
        static bool CheckIfBigger(int[] array, int index)
        {
            if (index == 0 || index == array.Length - 1)
            {
                return false;
            }
            return ((array[index - 1] < array[index]) && (array[index + 1] < array[index]));
        }
        static int CheckArray(int[] array)
        {
            int index = -1;
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (CheckIfBigger(array, i) == true)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
