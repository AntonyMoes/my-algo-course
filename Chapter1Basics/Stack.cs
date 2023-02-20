namespace Course.Chapter1Basics; 

public class Stack<T> {
    private readonly IDynamicArray<T> _array;

    public Stack(IDynamicArray<T> array) {
        _array = array;
    }

    public void Push(T element) {
        _array.PushBack(element);
    }

    public T Pop() {
        var result = _array[_array.Length - 1];
        _array.PopBack();
        return result;
    }

    public int Length => _array.Length;
}