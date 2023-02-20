namespace Course.Chapter1Basics; 

public interface IDynamicArray<T> {
    public T this[int idx] { get; set; }

    public void PushBack(T element);
    public void PopBack();

    public int Length { get; }
}