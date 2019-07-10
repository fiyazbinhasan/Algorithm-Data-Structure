using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayStack
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size = default(int);

        public void Push(T value)
        {
            if (_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }
            _items[_size] = value;
            _size++;
        }

        public T Pop()
        {
            if(_items.Length == 0){
                throw new InvalidOperationException("No value availalbe for pop");
            }
            _size--;
            return _items[_size];
        }

        public T Peek()
        {
            return _items[_size - 1];
        }

        public int Count => _size;

        public void Clear()
        {
            _size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
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
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

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
