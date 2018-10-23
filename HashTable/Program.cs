using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HashTable<string, string> hashTable = new HashTable<string, string>();
            hashTable.Add("Fiyaz", "Hasan");
            hashTable.Add("facebook", "http://www.facebook.com");
            Console.WriteLine(hashTable["Fiyaz"]);
            Console.WriteLine(hashTable["facebook"]);
            Console.ReadLine();
        }
    }
}
