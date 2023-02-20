namespace Course.Chapter2Sorting; 

public interface ISorting {
    void Sort<T>(ref T[] array, Comparison<T> comparison);
}