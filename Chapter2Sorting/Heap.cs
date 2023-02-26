namespace Course.Chapter2Sorting; 

public class Heap<T> : IPriorityQueue<T> {
    private readonly List<T> _elements = new List<T>() { default };
    
    private const int FirstElement = 1;

    public void Add(T element) {
        _elements.Add(element);
        HeapUp(_elements.Count - 1);
    }

    public T Remove() {
        var max = _elements[FirstElement];

        var lastIndex = _elements.Count - 1;
        _elements[FirstElement] = _elements[lastIndex];
        _elements.RemoveAt(lastIndex);
        HeapDown(1);

        return max;
    }

    void HeapUp(int index) {
        while (true) {
            if (index == FirstElement) {
                return;
            }

            var parentIndex = Parent(index);
            if (Comparer<T>.Default.Compare(_elements[index], _elements[parentIndex]) != 1) {
                return;
            }

            (_elements[index], _elements[parentIndex]) = (_elements[parentIndex], _elements[index]);

            index = parentIndex;
        }
    }

    void HeapDown(int index) {
        var childrenIndexes = Children(index);
        if (childrenIndexes.Length == 0) {
            return;
        }

        var childIndex = childrenIndexes.Length == 2 && Less(childrenIndexes[0], childrenIndexes[1])
            ? childrenIndexes[1]
            : childrenIndexes[0];

        if (Less(index, childIndex)) {
            (_elements[index], _elements[childIndex]) = (_elements[childIndex], _elements[index]);
            HeapDown(childIndex);
        }

        bool Less(int idx1, int idx2) {
            return Comparer<T>.Default.Compare(_elements[idx1], _elements[idx2]) == -1;
        }
    }

    private int Parent(int index) {
        return index / 2;
    }

    private int[] Children(int index) {
        var children = new List<int>();
        if (2 * index < _elements.Count) {
            children.Add(2 * index);
        }

        if (2 * index + 1 < _elements.Count) {
            children.Add(2 * index + 1);
        }

        return children.ToArray();
    }
}