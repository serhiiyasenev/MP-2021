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
    }
}
