using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T value)
        {
            _items.AddLast(value);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Nothing left to dequeue!");
            T value = _items.First.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Nothing left to dequeue!");
            return _items.First.Value;
        }

        public int Count 
        {
            get { return _items.Count; }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
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
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            foreach (var item in queue)
            {
                Console.Write($"{item} \t");
            }

            queue.Dequeue();
            Console.WriteLine();

            foreach (var item in queue)
            {
                Console.Write($"{item} \t");
            }

            Console.ReadLine();
        }
    }
}
