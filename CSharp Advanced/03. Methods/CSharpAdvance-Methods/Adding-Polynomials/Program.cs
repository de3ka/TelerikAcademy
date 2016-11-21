using System;

public class PolynomialAddition
{
    

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        string str = Console.ReadLine();
        string strr = Console.ReadLine();
        string[] str1 = str.Split(' ');
        string[] str2 = strr.Split(' ');

        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = Int32.Parse(str1[i]);
        }

        for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = Int32.Parse(str2[i]);
        }
        int[] result = AddPolynomials(arr1, arr2);

        Console.WriteLine(String.Join(" ", result));
    }

    public static int[] AddPolynomials(int[] a, int[] b)
    {
        int maxLength = Math.Max(a.Length, b.Length);
        int minLength = Math.Min(a.Length, b.Length);
        int[] result = new int[maxLength];

        int i;
        for (i = 0; i < minLength; i++)
        {
            result[i] = a[i] + b[i];
        }

        if (minLength < maxLength)
        {
            int[] c = (a.Length == maxLength) ? a : b;

            for (i = minLength; i < maxLength; i++)
            {
                result[i] = c[i];
            }
        }

        i = maxLength - 1;

        while (i > 0 && result[i] == 0)
        {
            i--;
        }

        if (i != maxLength - 1)
        {
            Array.Resize(ref result, i + 1);
        }

        return result;
    }
}
