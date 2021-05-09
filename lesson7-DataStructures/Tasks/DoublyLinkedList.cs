using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerator<T>
    {
        private T[] _array = new T[1];
        private int _i = -1;
        private int _arrayIndex = -1;

        public T this[int index]
        {
            get
            {
                if (index <= _arrayIndex)
                {
                    return _array[index];
                }

                return default;
            }
            set
            {
                if (index > _arrayIndex)
                {
                    return;
                }

                _array[index] = value;
            }
        }

        public int Length => _array.Length;

        public void Add(T e)
        {
            _arrayIndex++;

            if (_arrayIndex >= Length)
            {
                Array.Resize(ref _array, Length * 2);
            }

            _array[_arrayIndex] = e;
        }

        public void AddAt(int index, T e)
        {
            if (index < -1|| index > _arrayIndex + 1)
            {
                throw new IndexOutOfRangeException("Index should start from -1 and should not be more than DoublyLinkedList index + 1");
            }

            _arrayIndex++;

            if (index >= Length)
            {
                Array.Resize(ref _array, Length * 2);
            }

            for (var i = index; i <= _arrayIndex; i++)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = e;

        }

        public T ElementAt(int index)
        {
            var element = _array[index];
            return element;
        }

        public void Remove(T item)
        {
            var start = Array.IndexOf(_array, item);

            if (start == -1) return;
            for (var i = start; i <= _arrayIndex - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _arrayIndex--;
            Array.Resize(ref _array, _arrayIndex + 1);
        }

        public T RemoveAt(int index)
        {

            if (index < 0 || index > _arrayIndex)
            {
               throw new IndexOutOfRangeException("Index should start from 0 and should not be more than DoublyLinkedList index");
            }
            for (var i = index; i <= _arrayIndex - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _arrayIndex--;
            Array.Resize(ref _array, _arrayIndex + 1);
            return default;
        }

        public bool MoveNext()
        {
            _i++;
            return _i < Length;
        }

        public void Reset()
        {
            _i = -1;
        }

        object IEnumerator.Current => Current;

        public T Current => _array[_i];

        public IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            _array = null;
            // and ?
        }
    }
}
