using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTableArray<TKey, TValue>
    {
        HashTableArrayNode<TKey, TValue>[] _array;

        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (HashTableNodePair<TKey, TValue> pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        public void Clear()
        {
            foreach (HashTableArrayNode<TKey, TValue> node in _array)
            {
                node.Clear();
            }
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TValue value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TKey key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }
    }
}
