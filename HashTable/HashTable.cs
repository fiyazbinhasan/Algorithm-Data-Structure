using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        decimal _fillFactor = 0.75M;

        int _maxItemsAtCurrentSize;

        int _count;

        HashTableArray<TKey, TValue> _array;

        public HashTable() : this(1000)
        { }

        public HashTable(int initialCapacity)
        {

            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("initialCapacity");
            }

            _array = new HashTableArray<TKey, TValue>(initialCapacity);

            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;
        }

        public void Add(TKey key, TValue value)
        {
            if (_count >= _maxItemsAtCurrentSize)
            {
                HashTableArray<TKey, TValue> largerArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);

                foreach (HashTableNodePair<TKey, TValue> node in _array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                _array = largerArray;

                _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
            }

            _array.Add(key, value);
            _count++;
        }

        public bool Remove(TKey key)
        {
            bool removed = _array.Remove(key);
            if (removed)
            {
                _count--;
            }

            return removed;
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsValue(TValue value)
        {
            foreach (TValue foundValue in _array.Values)
            {
                if (value.Equals(foundValue))
                {
                    return true;
                }
            }

            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!_array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("key");
                }

                return value;
            }
            set
            {
                _array.Update(key, value);
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (TKey key in _array.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (TValue value in _array.Values)
                {
                    yield return value;
                }
            }
        }

        public void Clear()
        {
            _array.Clear();
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }
    }
}
