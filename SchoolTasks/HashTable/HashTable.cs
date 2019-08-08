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
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % storage.Length);
        }

        public void Clear()
        {
            for (var i = 0; i < storage.Length; i++)
            {
                storage[i] = null;
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            var index = GetIndex(item);

            if (storage[index] == null)
            {
                return false;
            }

            return storage[index].Contains(item);
        }

        public void Add(T item)
        {
            var index = GetIndex(item);

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
            var index = GetIndex(item);

            if (storage[index] == null)
            {
                return false;
            }

            if (!storage[index].Remove(item))
            {
                return false;
            }

            Count--;

            modCount++;

            if (storage[index].Count == 0)
            {
                storage[index] = null;
            }

            return true;

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

            var i = arrayIndex;
            foreach (var item in this)
            {
                array[i] = item;
                i++;
            }
        }

        private int? GetNextListIndex(int index)
        {
            int i = index;

            if (i == storage.Length)
            {
                return null;
            }

            while (storage[i] == null)
            {
                i++;

                if (i == storage.Length)
                {
                    return null;
                }
            }

            return i;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int enumeratorModCount = modCount;

            int? currentListIndex = GetNextListIndex(0);

            while (currentListIndex != null)
            {
                LinkedList<T> currentList = storage[currentListIndex.Value];

                foreach (T item in currentList)
                {
                    if (enumeratorModCount != modCount)
                    {
                        throw new InvalidOperationException("Collection was modified");
                    }
                    yield return item;
                }

                currentListIndex = GetNextListIndex(currentListIndex.Value + 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}