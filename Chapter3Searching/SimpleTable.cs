namespace Course.Chapter3Searching; 

public class SimpleTable<TKey, TValue> : ISymbolTable<TKey, TValue> {
    private readonly List<(TKey, TValue)> _elements = new List<(TKey, TValue)>();

    public void Add(TKey key, TValue value) {
        if (Contains(key)) {
            throw new ArgumentOutOfRangeException();
        }

        _elements.Add((key, value));
    }

    public bool Contains(TKey key) {
        foreach (var (k, _) in _elements) {
            if (Equals(k, key)) {
                return true;
            }
        }

        return false;
    }

    public bool Remove(TKey key) {
        var indexToRemove = -1;
        for (var i = 0; i < _elements.Count; i++) {
            var (currentKey, _) = _elements[i];
            if (Equals(currentKey, key)) {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove == -1) {
            return false;
        }

        _elements.RemoveAt(indexToRemove);
        return true;
    }

    public TValue Get(TKey key) {
        foreach (var (k, value) in _elements) {
            if (Equals(k, key)) {
                return value;
            }
        }

        throw new ArgumentOutOfRangeException();
    }
}