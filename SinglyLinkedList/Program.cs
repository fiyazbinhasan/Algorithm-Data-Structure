using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = head;
            head = node;
            head.Next = temp;
            if (count == 0)
            {
                tail = head;
            }
            count++;
        }
        public void AddLast(LinkedListNode<T> node)
        {
            if (count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            count++;
        }

        public void RemoveFirst()
        {
            count--;
            if (count == 0)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
            }
        }
        public void RemoveLast()
        {
            count--;
            if (count == 0)
            {
                head = null;
                tail = null;
            }
            LinkedListNode<T> current = head;
            while (current.Next != tail)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(new LinkedListNode<int>(5));
            list.AddLast(new LinkedListNode<int>(6));
            //list.AddLast(new LinkedListNode<int>(7));
            list.RemoveLast();
            foreach (var node in list)
            {
                Console.WriteLine(node);
            }
            Console.ReadLine();
        }
    }
}
