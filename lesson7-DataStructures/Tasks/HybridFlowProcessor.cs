using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T> where T : IEquatable<T>
    {
        private readonly DoublyLinkedList<T> _items = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (_items.Length == 0) throw new InvalidOperationException();
            return _items.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (_items.Length == 0) throw new InvalidOperationException();
            return _items.RemoveAt(0);
        }

        public void Push(T item)
        {
            _items.AddAt(0, item);
        }
    }
}
