using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; }

        public Node<T> Previous { get; set; }

        public Node<T> Next { get; set; }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerator<T>
    {

        public DoublyLinkedList()
        {
            Head = Tail;
        }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public int Length => FromHeadToTail(Head);

        private int FromHeadToTail(Node<T> node, int counter = 0)
        {
            
            if (node != null)
            {
                counter++;
                FromHeadToTail(node.Next, counter);
            }
            return counter;
        }

        private Node<T> FindNodeByValue(Node<T> node, T value)
        {
            if (node != null && node.Value.Equals(value))
            {
                return node;
            }

            if (node != null && node.Next == null)
            {
                return null;
            }

            return FindNodeByValue(node?.Next, value);
        }

        public void Add(T e)
        {
            var node = new Node<T>(e) { Next = null, Previous = Tail };

            if (Head == null)
            {
                Head = node;
            }

            
            Tail = node;
        }

        public void AddAt(int index, T e)
        {


        }

        public T ElementAt(int index)
        {
            return default;
        }

        public void Remove(T e)
        {
            if (Head.Value.Equals(e))
            {
                
            }

            if (Tail.Value.Equals(e))
            {
                if (Tail.Previous != null)
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
                
            }

            var node = FindNodeByValue(Head, e);

            if (node != null)
            {
                
            }

        }

        public T RemoveAt(int index)
        {


            return default;
        }

        public bool MoveNext()
        {
            return default;
        }

        public void Reset()
        {
           
        }

        public T Current { get; }

        object? IEnumerator.Current => Current;


        public void Dispose()
        {
            // and ?
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
