using System;
using Utility;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Pushes the largest element to the the end of the array (wall) */
            /* Move the wall a step ahead since the last element is sorted already */

            var arr = IOUtility.CreateArrayByInput();
             
            var wall = arr.Length; 

            while(wall >= 0)
            {
                for (int i = 0; i < wall ; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }

                wall--;
            }

            IOUtility.PrintArray(arr);

            // [2, 4, 1, 3]
            // wall = 4
            // --------------------- outer
            // wall >= 0 true
            // --------------------- inner
            // a[0] > a[1] => 2 > 4 false
            // --------------------- inner
            // a[1] > a[2] => 4 > 1 true
            // swap => [2, 1, 4, 3]
            // --------------------- inner
            // a[2] > a[3] => 4 > 3 true
            // swap => [2, 1, 3, 4]
            // wall = 3
            // --------------------- outer
            // wall >= 0 true;
            // --------------------- inner
            // a[0] > a[1] => 2 > 1 true
            // swap => [1, 2, 3, 4]
            // --------------------- inner

            // Finish looping although the array is sorted.

            /* 
             * Algorithm can be optimised by maintaining a flag
             * After itering over the inner loop if the value of the flag is still fale, 
             * then there is nothing left to swap and we can break from the outer loop 
             */
        }
    }
}
