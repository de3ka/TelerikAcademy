using System;
using Assertions.SearchingAlgorithms;
using Assertions.SortingAlgorithms;

namespace Assertions
{
    public class TestProgram
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("array = [{0}]", string.Join(", ", arr));
            SortingAlgorithm.SelectionSort(arr);
            Console.WriteLine("sorted array = [{0}]", string.Join(", ", arr));

            //SortingAlgorithm.SelectionSort(new int[0]); // Test sorting empty array
            //SortingAlgorithm.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(SearchingAlgorithm.BinarySearch(arr, -1000));
            Console.WriteLine(SearchingAlgorithm.BinarySearch(arr, 0));
            Console.WriteLine(SearchingAlgorithm.BinarySearch(arr, 17));
            Console.WriteLine(SearchingAlgorithm.BinarySearch(arr, 10));
            Console.WriteLine(SearchingAlgorithm.BinarySearch(arr, 1000));
        }
    }
}
