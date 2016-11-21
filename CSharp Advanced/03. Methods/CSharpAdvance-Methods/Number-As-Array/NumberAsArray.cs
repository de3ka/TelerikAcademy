using System;
using System.Collections.Generic;
using System.Text;

namespace Number_As_Array
{
    public class NumberAsArray
    {
        private const int MAX_LENGTH = 10000;

        public static void Main()
        {
            string dims = Console.ReadLine();
            string[] dim = dims.Split(' ');

            int size1 = Int32.Parse(dim[0]);
            int size2 = Int32.Parse(dim[1]);

            string str = Console.ReadLine();
            string strr = Console.ReadLine();

            string[] str1 = str.Split(' ');
            string[] str2 = strr.Split(' ');

            byte[] arr1 = new byte[size1];
            byte[] arr2 = new byte[size2];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = Byte.Parse(str1[i]);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = Byte.Parse(str2[i]);
            }

            string total = SumArrays(arr1, arr2);
            string final = Reverse(total);
            string[] finalToPrint = new string[final.Length + final.Length - 1];

            int j = 0;

            for (int i = 0; i < finalToPrint.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(final[j]);
                    j++;
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }

        private static string SumArrays(byte[] firstArray, byte[] secondArray)
        {
            List<byte> maxArray = new List<byte>();
            List<byte> minArray = new List<byte>();

            if (firstArray.Length > secondArray.Length)
            {
                maxArray.AddRange(firstArray);
                minArray.AddRange(secondArray);
            }
            else
            {
                maxArray.AddRange(secondArray);
                minArray.AddRange(firstArray);
            }

            int minLength = minArray.Count;
            int maxLength = maxArray.Count;
            int addition = 0;
            int sum;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < minLength; i++)
            {
                sum = minArray[i] + maxArray[i] + addition;
                if (sum >= 10)
                {
                    addition = 1;
                    sum = sum % 10;
                    result.Append(sum);
                }
                else
                {
                    result.Append(sum);
                    addition = 0;
                }
            }

            for (int j = minLength; j < maxLength; j++)
            {
                sum = maxArray[j] + addition;
                if (sum >= 10)
                {
                    addition = 1;
                    sum = sum % 10;
                    result.Append(sum);
                }
                else
                {
                    result.Append(sum);
                    addition = 0;
                }
            }

            if (addition == 1)
            {
                result.Append(1);
            }

            char[] reversed = (result.ToString()).ToCharArray();
            result.Clear();

            for (int i = reversed.Length - 1; i >= 0; i--)
            {
                result = result.Append(reversed[i]);
            }

            return result.ToString();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}