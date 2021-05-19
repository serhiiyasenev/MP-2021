using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;
using Tasks.DoublyLinkedList;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> Value { get; set; }

        public DoublyLinkedList()
        {
            Value = new Node<T>();
            Value.Next = Value;
            Value.Previous = Value;
            Length = 0;
        }

        public int Length { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T e)
        {
            AddAt(Length, e);
        }

        public void AddAt(int index, T e)
        {
            var currentItem = index == Length ? Value : GetNodeByIndex(index);
            var node = new Node<T>(e, currentItem.Previous, currentItem);
            currentItem.Previous.Next = node;
            currentItem.Previous = node;
            Length++;
        }
        
        public T ElementAt(int index)
        {
            return GetNodeByIndex(index).Value;
        }

        public void Remove(T item)
        {
            var node = GetFirstNodeByValue(item);
            if (node == null) return;

            RemoveNode(node);
        }

        private Node<T> GetNodeByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> node = Value;
            if (index < Length / 2)
            {
                for (var i = -1; i < index; i++)
                    node = node.Next;
            }
            else
            {
                for (var i = 0; i < Length - index; i++)
                    node = node.Previous;
            }

            return node;
        }

        private Node<T>? GetFirstNodeByValue(T item)
        {
            var node = Value;

            for (var i = 0; i < Length; i++)
            {
                node = node.Next;
                if (node.Equals(item))
                {
                    return node;
                }
            }

            return null;
        }

        public T RemoveAt(int index)
        {
            var node = GetNodeByIndex(index);
            RemoveNode(node);
            return node.Value;
        }

        private void RemoveNode(Node<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            Length--;
        }
    }
}
