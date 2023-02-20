namespace Course.Chapter1Basics; 

public class List<T> : IDynamicArray<T> {
    private Node _head;
    private Node _tail;

    public T this[int idx] {  // O(N)
        get {
            if (idx < 0) {
                throw new IndexOutOfRangeException();
            }

            var i = 0;
            var currentNode = _head;
            while (currentNode != null) {
                if (i == idx) {
                    return currentNode.Value;
                }

                i++;
                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException();
        }
        set {
            
            if (idx < 0) {
                throw new IndexOutOfRangeException();
            }

            var i = 0;
            var currentNode = _head;
            while (currentNode != null) {
                if (i == idx) {
                    currentNode.Value = value;
                    return;
                }

                i++;
                currentNode = currentNode.Next;
            }

            throw new IndexOutOfRangeException();
        }
    }

    public void PushBack(T element) {  // O(1)
        Length++;

        var newNode = new Node {
            Value = element,
            Next = null
        };

        if (_tail == null) {
            _head = newNode;
            _tail = newNode;
        } else {
            _tail.Next = newNode;
        }
    }

    public void PopBack() {  // O(N)
        if (_head == null) {
            throw new Exception();
        }

        Length--;

        if (_tail == _head) {
            _head = null;
            _tail = null;
            return;
        }

        var preTail = _head;
        while (preTail.Next != _tail) {
            preTail = preTail.Next;
        }

        preTail.Next = null;
    }

    public int Length {  // O(1)
        // get {
        //     var length = 0;
        //     var currentNode = _head;
        //     while (currentNode != null) {
        //         length++;
        //         currentNode = currentNode.Next;
        //     }
        //
        //     return length;
        // }
        get;
        private set;
    }

    private class Node {
        public T Value;
        public Node Next;
    }
}