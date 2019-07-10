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
        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; set; }
    }

    class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;
        private int _count;

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = _head;
            _head = node;
            _head.Next = temp;
            if (_count == 0)
                _tail = _head;
            _count++;
        }
        public void AddLast(LinkedListNode<T> node)
        {
            if (_count == 0)
                _head = node;
            else
                _tail.Next = node;
            _tail = node;
            _count++;
        }

        public void RemoveFirst()
        {
            _count--;
            if (_count == 0)
                _head = _tail = null;
            else
                _head = _head.Next;
        }
        public void RemoveLast()
        {
            _count--;
            if (_count == 0)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                LinkedListNode<T> current = _head;
                while (current.Next != _tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                _tail = current;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;
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

    static class Program
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
