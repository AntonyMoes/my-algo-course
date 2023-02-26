namespace Course.Chapter3Searching;

public class ListHashTable<TKey, TValue> : ISymbolTable<TKey, TValue> {
    private readonly Func<TKey, int> _hasher;
    private const int ArraySize = 2;
    private readonly List<(TKey, TValue)>[] _elements = new List<(TKey, TValue)>[ArraySize];

    public ListHashTable(Func<TKey, int> hasher) {
        _hasher = hasher;
    }

    public void Add(TKey key, TValue value) {
        if (Contains(key)) {
            throw new ArgumentOutOfRangeException();
        }

        var list = GetSlot(key);
        list.Add((key, value));
    }

    public bool Contains(TKey key) {
        var list = GetSlot(key);

        foreach (var (k, v) in list) {
            if (Equals(k, key)) {
                return true;
            }
        }

        return false;
    }

    public bool Remove(TKey key) {
        var list = GetSlot(key);

        var indexToRemove = -1;
        for (var i = 0; i < list.Count; i++) {
            var (k, v) = list[i];
            if (Equals(k, key)) {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove == -1) {
            return false;
        }

        list.RemoveAt(indexToRemove);
        return true;
    }

    private List<(TKey, TValue)> GetSlot(TKey key) {
        var hash = _hasher(key);
        var index = hash % ArraySize;
        return _elements[index];
    }

    public TValue Get(TKey key) {
        var list = GetSlot(key);

        foreach (var (k, v) in list) {
            if (Equals(k, key)) {
                return v;
            }
        }

        throw new ArgumentOutOfRangeException();
    }
}