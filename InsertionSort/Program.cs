using Utility;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TODO: Start with everything after the first element is unsorted */
            /* Array with a single element is always sorted */
            /* Check the current element value with the previous one */
            /* Clauses: Swap if the previous element is greater than the current element 
             * and the current element index is greater than 0 */

            var arr = IOUtility.CreateArrayWithElements();

            for (int i = 1; i < arr.Length; i++)
            {
                var value = arr[i];

                var step = i;

                while (step > 0 && arr[step - 1] > value)
                {
                    var temp = arr[step - 1];
                    arr[step - 1] = arr[step];
                    arr[step] = temp;

                    step--;
                }

                arr[step] = value;
            }

            IOUtility.PrintArrayElements(arr);
        }
    }
}
