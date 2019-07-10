using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("No value available for pop");
            T value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            return _list.First.Value;
        }

        public int Count => _list.Count;

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
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
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            foreach (var item in stack)
            {
                Console.Write($"{item} \t");
            }

            stack.Pop();
            Console.WriteLine();

            foreach (var item in stack)
            {
                Console.Write($"{item} \t");
            }

            Console.ReadLine();
        }
    }
}
