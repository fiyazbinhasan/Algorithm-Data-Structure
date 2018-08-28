using System;
using Utility;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = IOUtility.CreateArrayByInput();
            
            /* 
             * Don't need to loop around till the last one
             * The array will be sorted before reaching the second last element
            */

            for (int i = 0; i < arr.Length - 1; i++) 
            {
                var minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                var temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            IOUtility.PrintArray(arr);

            // [2, 4, 1, 3]
            // minIndex = 0
            // 4 < 2 false;
            // 1 < 2 true;
            // minIndex = 2
            // 3 < 1 false
            // swap => [1, 4, 2, 3]
            // -------------
            // minIndex = 1
            // 2 < 4  true;
            // minIndex = 2
            // 3 < 2 false;
            // swap => [1, 2, 4, 3]
            // -------------
            // minIndex = 2
            // 3 < 4 truel
            // minIndex = 3
            // swap => [1, 2, 3, 4]
        }
    }
}
