using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
    class LinkedList<T> : IEnumerable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        private int _count;

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = _head;
            _head = node;
            _head.Next = temp;

            if (_count == 0)
                _tail = _head;
            else
                temp.Previous = _head;

            _count++;
        }
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (_count == 0)
                _head = node;
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            _count++;
        }

        public void RemoveFirst()
        {
            _count--;
            if (_count == 0)
                _head = _tail = null;
            else
            {
                _head = _head.Next;
                _head.Previous = null;
            }
        }
        public void RemoveLast()
        {
            _count--;
            if (_count == 0)
            {
                _head = _tail = null;
            }
            else
            {
                _tail.Previous.Next = null;
                _tail = _tail.Previous;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = _head;
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
            list.AddFirst(new DoublyLinkedListNode<int>(5));
            list.AddFirst(new DoublyLinkedListNode<int>(6));
            list.AddFirst(new DoublyLinkedListNode<int>(7));
            list.RemoveLast();
            list.RemoveLast();
            foreach (var node in list)
            {
                Console.WriteLine(node);
            }
            Console.ReadLine();
        }
    }
}
