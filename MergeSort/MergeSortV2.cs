using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MergeSortV2
    {
        public int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1) return arr;

            var m = arr.Length / 2;

            var left = new List<int>();
            var right = new List<int>();
            
            for (var i = 0; i < m; i++) left.Add(arr[i]);

            for (var i = m; i < arr.Length; i++) right.Add(arr[i]);

            return Merge(MergeSort(left.ToArray()), MergeSort(right.ToArray()));
        }

        private int[] Merge(int[] left, int[] right)
        {
            var result = new List<int>();
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Length)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Length)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result.ToArray();
        }
    }
}
