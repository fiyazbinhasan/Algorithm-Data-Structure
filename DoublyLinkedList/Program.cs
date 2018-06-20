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
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
    class LinkedList<T> : IEnumerable<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> tail;
        private int count;

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            // null <- 5 <-> 6 <-> 7<->
            //

            DoublyLinkedListNode<T> temp = head;
            head = node;
            head.Next = temp;

            if (count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = head;
            }

            count++;
        }
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
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
                head.Previous = null;
            }
        }
        public void RemoveLast()
        {
            count--;
            if (count == 0)
            {
                head = tail = null;
            } // 5 <-> 6 <-> 7

            tail.Previous.Next = null;
            tail = tail.Previous;
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = head;
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
