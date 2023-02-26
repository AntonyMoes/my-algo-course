namespace Course.Chapter2Sorting; 

public interface IPriorityQueue<T> {
    void Add(T element);
    T Remove();
}