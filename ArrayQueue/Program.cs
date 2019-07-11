using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        private int _size;
        private int _head;
        private int _tail;

        public void Enqueue(T value)
        {
            if (_size == _items.Length)
            {
                var newLength = _size == 0 ? 4 : _size * 2; // for the first time allocate 4 indeces
                var newArray = new T[newLength];

                if (_size > 0)
                {
                    int index = 0;

                    if (_tail < _head)
                    {
                        for (int i = _head; i < _items.Length; i++)
                        {
                            newArray[index++] = _items[i];
                        }

                        for (int i = 0; i <= _tail; i++)
                        {
                            newArray[index++] = _items[i];
                        }

                    }
                    else
                    {
                        for (int i = _head; i <= _tail; i++)
                        {
                            newArray[index++] = _items[i];
                        }
                    }

                    _head = 0;
                    _tail = index - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = newArray;
            }

            if (_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = value;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Nothing left to dequeue!");

            var value = _items[_head];

            if (_head == _items.Length - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;
            return value;
        }

        public T Peek()
        {
            return _items[_head];
        }

        public int Count => _size;

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (int i = _head; i < _items.Length; i++)
                    {
                        yield return _items[i];
                    }
                    for (int i = 0; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _head; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
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
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

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

            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine();

            foreach (var item in queue)
            {
                Console.Write($"{item} \t");
            }

            Console.ReadLine();
        }
    }
}
