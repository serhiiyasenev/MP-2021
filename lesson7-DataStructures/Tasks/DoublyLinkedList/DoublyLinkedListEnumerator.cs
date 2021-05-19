using System.Collections;
using System.Collections.Generic;

namespace Tasks.DoublyLinkedList
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly Node<T> _value;
        private Node<T> _currentNode;

        public DoublyLinkedListEnumerator(Node<T> value)
        {
            _value = _currentNode = value;
        }

        public bool MoveNext()
        {
            _currentNode = _currentNode.Next;
            return _currentNode != _value;
        }

        public void Reset()
        {
            _currentNode = _value;
        }

        public T Current => _currentNode.Value;

        object IEnumerator.Current => Current; // why object?

        public void Dispose()
        {
            // what should be here?
        }
    }
}
