using System.Collections;
using System.Collections.Generic;

namespace Tasks.DoublyLinkedList
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly Node<T> _start;
        private Node<T> _currentNode;

        public DoublyLinkedListEnumerator(Node<T> value)
        {
            _start = value;

            _currentNode = _start;
        }

        public bool MoveNext()
        {
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = _start;
        }

        public T Current
        {
            get
            {
                var value = _currentNode.Value;
                _currentNode = _currentNode.Next;
                return value;
            }
        }

        object IEnumerator.Current => Current; // why object?

        public void Dispose()
        {
            // what should be here?
        }
    }
}
