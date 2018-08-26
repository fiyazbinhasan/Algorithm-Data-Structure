using Utility;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = IOUtility.CreateArrayWithElements();

            for (int i = 1; i < arr.Length; i++)
            {
                var value = arr[i];

                var step = i;

                while (step > 0 && arr[step - 1] > value)
                {
                    arr[step] = arr[step - 1];

                    step--;
                }

                arr[step] = value;
            }

            IOUtility.PrintArrayElements(arr);
        }
    }
}
