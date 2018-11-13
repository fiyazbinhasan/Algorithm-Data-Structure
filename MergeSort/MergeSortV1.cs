using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    public class MergeSortV1
    {
        public void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }

            // arr = [10, 40, 5, 23, 2]

            // MergeSort(arr, 0, 4)
            // 0 < 4
            // m  = 2

            // MergeSort(arr, 0, 2)
            // 0 < 2
            // m = 1

            // MergeSort(arr, 0, 1)
            // 0 < 1
            // m = 0

            // MergeSort(arr, 0, 0)
            // 0 < 0 false         // Start with MergeSort(arr, 0, 1)

            // MergeSort(arr, m + 1, r)
            // MergeSort(arr, 1, 1)       
            // 1 < 1 false         // Start with Merge(arr, 0, 0, 1)

            // Merge(arr, l, m, r)
            // Merge(arr, 0, 0, 1)
            // nl = 1, nr = 1
            // left[0] = arr[0] = 10
            // right[0] = arr[1] = 40
            // k = 0
            // 0 < 1 && 0 < 1
            // left[0] <= right[0] : 10 <= 40 true
            // arr[0] = left[0] : arr[0] = 10;
            // i = 1, k = 1
            // 1 < 1 && 0 < 1 false

            // 1 < 1 false
            // 0 < 1 true
            // arr[1] = right[0] : arr[1] = 40
            // j = 1, k = 2
            // 1 < 1 false       // Start with MergeSort(arr, 0, 2)


            // MergeSort(arr, 2, 2)
            // 2 < 2 false         // Start with Merge(arr, 0, 1, 2)

            // Merge(arr, 0, 1, 2)
            // nl = 2, nr = 1;
            // left[0] = 10, left[1] = 40
            // right[0] = 5
            // k = 0
            // 0 < 2 && 0 < 1
            // left[0] <= right[0] : 10 <= 5 false
            // arr[0] = right[0] : arr[0] = 5
            // k = 1
            // j = 1
            // 0 < 2 && 1 < 1 false


            // 0 < 2 
            // arr[k] = left[i] : arr[1] = left[0] : arr[1] = 10
            // k = 2
            // 1 < 2
            // arr[k] = left[i] : arr[2] = left[1] : arr[2] = 40
            // k = 3
            // 1 < 1 false     // Start with MergeSort(arr, 0, 4)

            // [5, 10, 40, 23, 2]

            // continue
        }

        public void Merge(int[] arr, int l, int m, int r)
        {
            int nL = m - l + 1;
            int nR = r - m;
            int i, j;

            int[] left = new int[nL];
            int[] right = new int[nR];

            for (i = 0; i < nL; ++i)
            {
                left[i] = arr[l + i];
            }
            for (j = 0; j < nR; ++j)
            {
                right[j] = arr[m + 1 + j];
            }

            i = 0; j = 0;
            int k = l;

            while (i < nL && j < nR)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
