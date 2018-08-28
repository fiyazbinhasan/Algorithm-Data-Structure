using System;
using Utility;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Build a max heap from the array of elements. Devide the array into halves and run max heapify.
             *  Compare a root with its left and right child in a bottom up recursive fasion.
             *  Replace the first element of the max heap with the last and run max heapify on starting form the 0th index
             * */

            var arr = new int[] { 2, 4, 1, 8, 6, 0, 3 };


            var heapSize = arr.Length - 1;

            for(var i = heapSize/2; i >= 0; i--)
                Heapify(arr, i, heapSize);

            for (int i = heapSize; i >= 0; i--)
            {
                var temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;

                Heapify(arr, 0, i);
            }

            IOUtility.PrintArray(arr);

            /*
             *  [2, 4, 1, 8, 6, 0, 3]
             *  length = 7
             *                2 (i = 0) 
             *              /    \
             *             /      \
             *            /        \
             *           /          \
             *      (1) 4            1 (2)
             *         / \          / \
             *        /   \        /   \
             *       /     \      /     \
             *  (3) 8   (4) 6    0 (5)   3 (6)
             *  
             *  ----------------------- Heapify
             *                8 (i = 0) 
             *              /    \
             *             /      \
             *            /        \
             *           /          \
             *      (1) 6            1 (2)
             *         / \          / \
             *        /   \        /   \
             *       /     \      /     \
             *  (3) 4   (4) 2    0 (5)   3 (6)
             *  
             *  ----------------------- Replace 8 with 3, remove 8 and start heapify on index 0  
             *                3 (i = 0) 
             *              /    \
             *             /      \
             *            /        \
             *           /          \
             *      (1) 6            1 (2)
             *         / \          / 
             *        /   \        /   
             *       /     \      /     
             *  (3) 4   (4) 2    0 (5)   
             */
        }

        private static void Heapify(int[] arr, int root, int heapSize)
        {
            var largest = root;
            var left = 2 * root + 1;
            var right = 2 * root + 2;

            if (left < heapSize && arr[left] > arr[largest])
                largest = left;
            if (right < heapSize && arr[right] > arr[largest])
                largest = right;
            if(largest != root)
            {
                var temp = arr[root];
                arr[root]= arr[largest];
                arr[largest] = temp;

                Heapify(arr, largest, heapSize);
            }
        }
    }
}
