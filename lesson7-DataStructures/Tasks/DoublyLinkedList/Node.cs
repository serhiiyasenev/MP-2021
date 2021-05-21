namespace Tasks.DoublyLinkedList
{
    public class Node<T>
    {
        public Node<T> Next;
        public Node<T> Previous;
        public T Value;

        public Node()
        {
        }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> previous, Node<T> next)
        {
            Previous = previous;
            Next = next;
            Value = value;
        }
    }
}
