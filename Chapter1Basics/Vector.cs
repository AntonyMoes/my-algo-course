namespace Course.Chapter1Basics; 

public class Vector<T> : IDynamicArray<T> {
    private const int InitialCapacity = 4;

    private T[] _array = new T[InitialCapacity];
    private int Capacity => _array.Length;

    public T this[int idx] {  // O(1)
        get {
            if (idx >= Length || idx < 0) {
                throw new IndexOutOfRangeException();
            }

            return _array[idx];
        }
        set {
            if (idx >= Length || idx < 0) {
                throw new IndexOutOfRangeException();
            }

            _array[idx] = value;
        }
    }

    public void PushBack(T element) { // O(1), но есть нюансы
        if (Length == Capacity) {
            var newArray = new T[Capacity * 2];
            for (var i = 0; i < Capacity; i++) {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        _array[Length] = element;
        Length++;
    }

    public void PopBack() {  // O(1)
        if (Length == 0) {
            throw new Exception();
        }

        Length--;
    }

    public int Length { get; private set; } = 0;
}