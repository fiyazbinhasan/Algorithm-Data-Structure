using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T value)
        {
            if(_items.Count == 0)
                _items.AddLast(value);
            else {
                var current = _items.First;
                while(current != null && current.Value.CompareTo(value) > 0) {
                    current = current.Next;
                }

                if (current == null)
                    _items.AddLast(value);
                else
                    _items.AddBefore(current, value);
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Nothing left to dequeue!");
            var value = _items.First.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Nothing left for peeking!");
            return _items.First.Value;
        }

        public int Count {
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
            queue.Enqueue(44);
            queue.Enqueue(45);
            queue.Enqueue(43);
            queue.Enqueue(42);

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

            queue.Enqueue(1);
            queue.Enqueue(46);

            Console.WriteLine();

            foreach (var item in queue)
            {
                Console.Write($"{item} \t");
            }

            Console.ReadLine();
        }
    }
}
