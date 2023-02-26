namespace Course.Chapter2Sorting; 

public class SimplePriorityQueue<T> : IPriorityQueue<T> {
    private readonly List<T> _elements = new List<T>();

    public bool IsEmpty => _elements.Count == 0;

    public void Add(T element) {
        // _elements.Add(element);

        var inserted = false;
        for (var i = 0; i < _elements.Count; i++) {
            if (Comparer<T>.Default.Compare(_elements[i], element) == 1) {
                _elements.Insert(i, element);
                inserted = true;
                break;
            }
        }

        if (!inserted) {
            _elements.Add(element);
        }
    }

    public T Remove() {
        // var maxIndex = 0;
        // var max = _elements[maxIndex];
        // for (var i = 0; i < _elements.Count; i++) {
        //     if (Comparer<T>.Default.Compare(_elements[i], max) == 1) {
        //         maxIndex = i;
        //         max = _elements[maxIndex];
        //     }
        // }
        //
        // _elements.RemoveAt(maxIndex);
        // return max;

        var maxIndex = _elements.Count - 1;
        var max = _elements[maxIndex];
        _elements.RemoveAt(maxIndex);
        return max;
    }
}