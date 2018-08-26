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
            /* Compare the elements of the unsorted array the elements of the sorted array and perform insertion */

            var arr = IOUtility.CreateArrayWithElements();

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

            IOUtility.PrintArrayElements(arr);

            // 2 4 8 1
            // [2] [4 8 1]
            // [2] > [4] no
            // [2, 4] [8 1]
            // [4] > [8] no
            // [2, 4, 8] [1]
            // [8] > [1] yes
            // [2, 4, 1, 8]
            // [2, 1, 4, 8]
            // [1, 2, 4, 8]
        }
    }
}
