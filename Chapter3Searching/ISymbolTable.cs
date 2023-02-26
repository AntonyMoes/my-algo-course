namespace Course.Chapter3Searching; 

public interface ISymbolTable<TKey, TValue> {
    public void Add(TKey key, TValue value);
    public bool Contains(TKey key);
    public bool Remove(TKey key);
    public TValue Get(TKey key);
}