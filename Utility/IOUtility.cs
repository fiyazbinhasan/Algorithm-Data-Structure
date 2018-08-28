using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    static class IOUtility
    {
        public static int[] CreateArrayByInput()
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

        public static int[] CreateArrayRandomly()
        {
            Random rnd = new Random();
            Int32 n = rnd.Next(5, 10);
            Console.WriteLine("Number of elements?");
            Console.WriteLine($"{n}");
            Console.WriteLine("-----------------------");

            int[] arr = new int[n];

            int i = 0;
            while (i < arr.Length)
            {
                arr[i] = rnd.Next(0, 100);
                Console.WriteLine($"{i}th element:\t{arr[i]}");
                i++;
            }
            return arr;
        }


        public static void PrintArray(int[] arr)
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
