using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;
using Tasks.DoublyLinkedList;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T> where T : IEquatable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Length = 0;
        }

        public int Length { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);
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
            var currentItem = index == Length ? Tail : GetNodeByIndex(index);
            var node = new Node<T>(e, currentItem, currentItem);
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


            Node<T> node1 = findNode(Head, 0);

            return node1;

            Node<T> findNode(Node<T> node, int nodeIndex)
            {
                // node null --> return null

                if (nodeIndex == index)
                {
                    return node;
                }
                else
                {
                    return findNode(node.Next, nodeIndex++);
                }
            }
        }

        private Node<T> GetFirstNodeByValue(T value) 
        {
            Node<T> node2 = findNode(Tail);

            return node2;


            Node<T> findNode(Node<T> node22)
            {
                if (node22 == null)
                {
                    return null;
                }
                if (node22.Value.Equals(value))
                {
                    return node22;
                }
                else
                {
                    return findNode(node22.Previous);
                }
            }
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
