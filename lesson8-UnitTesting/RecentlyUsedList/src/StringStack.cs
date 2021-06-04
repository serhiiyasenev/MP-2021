using System;
using System.Collections.Generic;

namespace RecentlyUsedList
{
    public class StringStack
    {
        public StringStack(int capacity = 5)
        {
            if(capacity <= 0)
                throw new ArgumentOutOfRangeException($"Capacity should be greater than zero: {capacity}");
            Capacity = capacity;
        }
        
        private readonly List<string> _storage = new List<string>();
        public int Count => _storage.Count;
        public int Capacity { get; }

        public void Push(string element)
        {
            if(string.IsNullOrEmpty(element))
                throw new ArgumentNullException($"Is null or empty {element}");
            
            if (_storage.Contains(element))
            {
                _storage.Remove(element);
            }

            if (Count == Capacity)
            {
                _storage.Remove(_storage[0]);
            }

            _storage.Add(element);
        }

        public bool Pop(string element)
        {
            if (string.IsNullOrEmpty(element))
                throw new ArgumentNullException($"Is null or empty {element}");

            if (_storage.Count == 0)
                throw new InvalidOperationException();

            return _storage.Remove(element);
        }

        public string this[int index]
        {
            get
            {
                if(index < 0)
                    throw new IndexOutOfRangeException();

                return _storage[Count - 1 - index];
            }
            set
            {
                if(index < 0)
                    throw new IndexOutOfRangeException();

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException($"Is null or empty {value}");


                _storage[Count - 1 - index] = value;
            }
        }
    }
}