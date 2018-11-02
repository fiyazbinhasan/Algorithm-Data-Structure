using System;
using Utility;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 2, 0, 1, 3 };

            MergeSort(arr, arr.Length);
            IOUtility.PrintArray(arr);


            // arr = [4, 2, 0, 1, 3] arr.Length = 5                                 
            // MergeSort(arr, n)
            // 5 < 2 true
            // L[2], R[3]
            // L[2] = [4, 2]
            // R[3] = [0, 1, 3]
            // MergeSort(leftArray, mid) : MergeSort([4,2], 2)

            // 2 < 2 false
            // mid = 2/2 = 1
            // L[1], R[1]
            // L[1] = [4]
            // R[1] = [2]
            // MergeSort(leftArray, mid) : MergeSort([4], 1)

            // 1 < 2 return

            // Pop MergeSort([4], 1)

            // MergeSort(R[1], 1)
            // 1 < 2 return

            // Pop MergeSort([4, 2], 2)


        }

        public static void MergeSort(int[] arr, int n)
        {
            if (n < 2) return;
            int mid = n / 2;
            int i;

            int[] leftArray = new int[mid];
            int[] rightArray = new int[n - mid];


            for (i = 0; i < mid; i++) leftArray[i] = arr[i];
            for (i = mid; i < n; i++) rightArray[i - mid] = arr[i];

            MergeSort(leftArray, mid);
            MergeSort(rightArray, n - mid);
            Merge(arr, leftArray, rightArray);
        }

        public static void Merge(int[] arr, int[] leftArray, int[] rightArray)
        {
            int i, j, k;

            i = 0; j = 0; k = 0;

            while (i < leftArray.Length && j < rightArray.Length)
            {
                if (leftArray[i] < rightArray[j]) arr[k++] = leftArray[i++];
                else arr[k++] = rightArray[j++];
            }
            while (i < leftArray.Length) arr[k++] = leftArray[i++];
            while (j < rightArray.Length) arr[k++] = rightArray[j++];
        }
    }
}
