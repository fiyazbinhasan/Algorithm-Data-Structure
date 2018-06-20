using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> first = new Node<int> { Value = 3 };
            Node<int> middle = new Node<int> { Value = 4 };

            first.Next = middle;

            Node<int> last = new Node<int> { Value = 5 };

            middle.Next = last;

            PrintList(first);

            Console.ReadLine();
        }

        private static void PrintList(Node<int> node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
