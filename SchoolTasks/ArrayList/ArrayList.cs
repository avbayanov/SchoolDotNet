using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] array;
        private int modCount;

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public ArrayList()
        {
            array = new T[10];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("capacity must be >= 0", nameof(capacity));
            }

            array = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0 and < ArrayList.Count");
                }

                return array[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0 and < ArrayList.Count");
                }

                array[index] = value;

                modCount++;
            }
        }

        private void ResizeArray(int arrayLength)
        {
            T[] temp = new T[arrayLength];

            Array.Copy(array, 0, temp, 0, Math.Min(Count, arrayLength));

            array = temp;
        }

        private void CheckForFullAndDoubleCapacity()
        {
            if (Count == array.Length)
            {
                ResizeArray(array.Length * 2 + 1);
            }
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity > array.Length)
            {
                ResizeArray(capacity);
            }
        }

        public void TrimToCount()
        {
            if (Count == array.Length)
            {
                return;
            }

            ResizeArray(Count);
        }

        public void Clear()
        {
            Count = 0;

            modCount++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void Add(T item)
        {
            CheckForFullAndDoubleCapacity();

            array[Count] = item;

            Count++;

            modCount++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0 and < ArrayList.Count");
            }

            CheckForFullAndDoubleCapacity();

            Array.Copy(array, index, array, index + 1, Count - index);

            array[index] = item;

            Count++;

            modCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0 and < ArrayList.Count");
            }

            Array.Copy(array, index + 1, array, index, Count - index - 1);

            Count--;

            modCount++;
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

            Array.Copy(this.array, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int enumeratorModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (enumeratorModCount != modCount)
                {
                    throw new InvalidOperationException("Collection was modified");
                }

                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}