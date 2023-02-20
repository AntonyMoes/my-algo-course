namespace Course.Chapter1Basics; 

public class Queue<T> {
    private Node _head;
    private Node _tail;

    public void Enqueue(T element) {
        Length++;

        var newNode = new Node {
            Value = element,
            Next = null
        };

        if (_tail == null) {
            _head = _tail = newNode;
        } else {
            _tail.Next = newNode;
        }
    }

    public T Dequeue() {
        if (Length == 0) {
            throw new Exception();
        }

        var dequeuedNode = _head;
        if (dequeuedNode.Next != null) {
            _head = dequeuedNode.Next;
        } else {
            _head = _tail = null;
        }

        return dequeuedNode.Value;
    }
    
    public int Length { get; private set; }

    private class Node {
        public T Value;
        public Node Next;
    }
}