using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    static class IOUtility
    {
        public static int[] CreateArrayWithElements()
        {
            Console.WriteLine("Number of elements?");
            Int32 n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------");

            int[] arr = new int[n];

            int i = 0;
            while(i < arr.Length)
            {
                Console.Write($"{i}th element:\t");
                arr[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }
            return arr;
        }

        public static void PrintArrayElements(int[] arr)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Sorted Array:");
            int i = 0;
            while (i < arr.Length)
            {
                Console.Write($"{arr[i]}\t");
                i++;
            }
            Console.ReadKey();
        }
    }
}
