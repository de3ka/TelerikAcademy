using System;

namespace Problem_18.RemoveElementsFromArray
{
    public class RemoveElementsFromArray
    {
        public static void Main()
        {
            uint n = GetArraySize();
            int[] arrayN = GetArray(n);
            int[] sortedArray = GetSortedArray(arrayN);
            Console.WriteLine(arrayN.Length - sortedArray.Length);
        }

        private static uint GetArraySize()
        {
            uint size = 0;
            if (uint.TryParse(Console.ReadLine(), out size))
            {
                return size;
            }
            else
            {
                return 0;
            }
        }

        private static int[] GetArray(uint arraySize)
        {
            int[] newArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if (!(int.TryParse(Console.ReadLine(), out newArray[i])))
                {
                    Console.WriteLine("\nWrong input!\n");
                }
            }
            return newArray;
        }

        private static int[] GetSortedArray(int[] array)
        {
            int[] length = new int[array.Length];
            int[] predecessor = new int[array.Length];
            length[0] = 1;
            predecessor[0] = -1;
            int maxLength = 0;
            int elementIndex = -1;
            for (int i = 1; i < array.Length; i++)
            {
                maxLength = 0;
                elementIndex = -1;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i])
                    {
                        if (length[j] > maxLength)
                        {
                            maxLength = length[j];
                            elementIndex = j;
                        }
                    }
                }
                if (elementIndex != -1)
                {
                    length[i] = maxLength + 1;
                }
                else
                {
                    length[i] = 1;
                }
                predecessor[i] = elementIndex;
            }
            maxLength = 0;

            for (int i = 0; i < length.Length; i++)
            {
                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    elementIndex = i;
                }
            }
            int[] sortedArray = new int[maxLength];
            int index = 0;

            while (elementIndex != -1)
            {
                sortedArray[index] = array[elementIndex];
                elementIndex = predecessor[elementIndex];
                index++;
            }
            Array.Reverse(sortedArray);
            return sortedArray;
        }
    }
}