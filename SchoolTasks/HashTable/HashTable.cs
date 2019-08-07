using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private LinkedList<T>[] storage;
        private int modCount;

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public HashTable()
        {
            storage = new LinkedList<T>[100];
        }

        public HashTable(int storageLength)
        {
            if (storageLength <= 0)
            {
                throw new ArgumentException("storageLength must be > 0", nameof(storageLength));
            }

            storage = new LinkedList<T>[storageLength];
        }

        private int GetIndex(T item)
        {
            return Math.Abs(item.GetHashCode() % storage.Length);
        }

        public void Clear()
        {
            for (int i = 0; i < storage.Length; i++)
            {
                storage[i] = null;
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (storage[index] == null)
            {
                return false;
            }

            return storage[index].Contains(item);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (storage[index] == null)
            {
                storage[index] = new LinkedList<T>();
            }

            storage[index].AddFirst(item);

            Count++;

            modCount++;
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (storage[index] == null)
            {
                return false;
            }

            if (storage[index].Remove(item))
            {
                Count--;

                modCount++;

                if (storage[index].Count == 0)
                {
                    storage[index] = null;
                }

                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "array must be not null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "arrayIndex must be >= 0");
            }

            if (Count + arrayIndex > array.Length)
            {
                throw new ArgumentException("Not enough space in array: (Count + arrayIndex) must be <= array.Length");
            }

            int i = 0;
            foreach (T item in this)
            {
                array[arrayIndex + i] = item;
                i++;
            }
        }

        private class HashTableEnumerator<T> : IEnumerator<T>
        {
            private readonly HashTable<T> hashTable;
            private int enumeratorModCount;

            private IEnumerator<T> currentListEnumerator;
            private int currentListIndex = -1;

            public T Current { get; private set; }

            public HashTableEnumerator(HashTable<T> hashTable)
            {
                this.hashTable = hashTable;

                enumeratorModCount = this.hashTable.modCount;
            }

            private bool GetNextListEnumerator()
            {
                currentListIndex++;

                if (currentListIndex == hashTable.storage.Length)
                {
                    return false;
                }

                while (hashTable.storage[currentListIndex] == null)
                {
                    currentListIndex++;

                    if (currentListIndex == hashTable.storage.Length)
                    {
                        return false;
                    }
                }

                currentListEnumerator = hashTable.storage[currentListIndex].GetEnumerator();

                return true;
            }

            public bool MoveNext()
            {
                if (enumeratorModCount != hashTable.modCount)
                {
                    throw new InvalidOperationException("Collection was modified");
                }

                if (currentListEnumerator == null)
                {
                    if (!GetNextListEnumerator())
                    {
                        return false;
                    }
                }

                if (currentListEnumerator.MoveNext())
                {
                    Current = currentListEnumerator.Current;

                    return true;
                }

                if (!GetNextListEnumerator())
                {
                    return false;
                }

                currentListEnumerator.MoveNext();
                Current = currentListEnumerator.Current;

                return true;
            }

            public void Reset()
            {
                currentListEnumerator = null;
                currentListIndex = -1;
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current => Current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new HashTableEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}