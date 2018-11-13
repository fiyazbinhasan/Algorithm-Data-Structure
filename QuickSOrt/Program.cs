using System;
using Utility;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * We start with an unsorted array and choose a pivot point (last element in this case)
             * Consider a wall at the beginning of the array
             * We start by comparing the pivot element with the first element
             * If it is lower than the pivot the wall is shifted to the right and the values are swapped
             * When all the comparisons are done, increment the wall and swap the value of it with the pivot
             * Return the wall so that we can divide the array into halves and apply the same technique for each array
             * Do this recursively until the front index is less than the rear index
             */
            var arr = IOUtility.CreateArrayRandomly();

            var p = 0;
            var r = arr.Length - 1;
            QuickSort(arr, p, r);

            IOUtility.PrintArray(arr);

            // [4, 2, 0, 1, 3] 
            // front = 0, rear = 4
            // pivot = 3, wall = -1
            
            // loop j = 0 to (rear - 1)
            // if a[0] = 4 <= 3 false
            
            // j = 1
            // a[1] = 2 <= 3 true
            // wall = 0
            // swap a[wall] = a[0] with a[1]
            // [2, 4, 0, 1, 3]

            // j = 2
            // a[2] = 0 <= 3 true
            // wall = 1
            // swap a[wall] = a[1] with a[2]
            // [2, 0, 4, 1, 3]

            // j = 3
            // a[3] = 1 <= 3 true
            // wall = 2
            // swap a[wall] = a[2] with a[3]
            // [2, 0, 1, 4, 3]

            // swap a[wall + 1] = a[3] = 4 with a[rear] = pivot = 3
            // [2, 0, 1, 3, 4]

            // divide the array into 2
            // array1 starts from 0, (wall + 1) - 1 
            // array2 starts from (wall + 1) + 1 to rear

        }

        private static void QuickSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(arr, p, r);
                QuickSort(arr, p, q - 1);
                QuickSort(arr, q + 1, r);
            }
        }

        private static int Partition(int[] arr, int p, int r)
        {
            var x = arr[r];

            var wall = p - 1;

            for (var j = p; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    wall++;
                    Swap(arr, wall, j);
                }
            }

            Swap(arr, wall + 1, r);
            return wall + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
