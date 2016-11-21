using System;

public class LargerThanNeighbours
{
    static void Main()
    {
        // input
        int size = int.Parse(Console.ReadLine());

        string str = Console.ReadLine();
        string[] str1 = str.Split(' ');
        int[] arr = new int[size];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Int32.Parse(str1[i]);
        }
        int count = 0;
        // invoking the method
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsLargerThanNeighbors(arr, i))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    public static bool IsLargerThanNeighbors(int[] nums, int i)
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