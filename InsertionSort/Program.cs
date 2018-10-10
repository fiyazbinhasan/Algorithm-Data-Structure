using Utility;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /* In place insertion sort */
            /* Imagine deviding the array into a sorted and an unsorted sub arrays */
            /* Array with single element is always sorted */
            /* Compare the elements of the unsorted array with the elements of the sorted array and perform insertion */

            var arr = IOUtility.CreateArrayByInput();

            for (int i = 1; i < arr.Length; i++)
            {
                var value = arr[i];

                var hole = i;

                while (hole > 0 && arr[hole - 1] > value)
                {
                    arr[hole] = arr[hole - 1];

                    hole--;
                }

                arr[hole] = value;
            }

            IOUtility.PrintArray(arr);

            // 2 4 8 1
            // value = a[1] = 4, hole = 1
            // 1 > 0 && a[0] = 2 > 4 false
            // a[1] = 4
            // ------------------- outer
            // value = a[2] = 8, hole = 2
            // 2 > 0 && a[1] = 4 > 8 false
            // a[2] = 8
            // ------------------- outer
            // value = a[3] = 1, hole = 3
            // ------------------- inner
            // 3 > 0 && a[2] = 8 > 1 true
            // a[3] = a[3 - 1] => a[3] = 8
            // [2, 4, _, 8], hole = 2, value = 1
            // ------------------- outer
            // 2 > 0 && a[1] = 4 > 1 true
            // ------------------- inner
            // a[2] = a[2 - 1] => a[2] = 4
            // [2, _, 4, 8], hole = 1, value = 1
            // ------------------- outer
            // 1 > 0 && a[0] = 2 > 1 true
            // ------------------- inner
            // a[1] = a[1 - 1] => a[1] = 2
            // [_, 2, 4, 8], hole = 0, value = 1

            // hole > 0 false
            // a[hole] = a[0] = 1
            // [1, 2, 4, 8]
        }
    }
}
