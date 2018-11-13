using System;
using Utility;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] {10, 40, 5, 23, 2};

            //var mergeSortV1 = new MergeSortV1();

            //mergeSortV1.MergeSort(arr, 0, arr.Length - 1);

            var mergeSortV2 = new MergeSortV2();

            IOUtility.PrintArray(mergeSortV2.MergeSort(arr));
        }
    }
}
