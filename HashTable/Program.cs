using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HashTable<string, string> hashTable = new HashTable<string, string>(100);
            hashTable.Add("name", "Fiyaz");
            hashTable.Add("github", "https://www.github.com/fiyazbinhasan");
            Console.WriteLine(hashTable["Fiyaz"]);
            Console.WriteLine(hashTable["facebook"]);
            Console.ReadLine();
        }
    }
}
