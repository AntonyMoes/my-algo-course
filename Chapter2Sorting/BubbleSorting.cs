namespace Course.Chapter2Sorting; 

public class BubbleSorting : ISorting {
    public void Sort<T>(ref T[] array, Comparison<T> comparison) {
        var sorted = false;
        while (!sorted) {
            sorted = true;

            for (var currentIdx = 0; currentIdx < array.Length - 1; currentIdx++) {
                var current = array[currentIdx];
                var next = array[currentIdx + 1];
                if (comparison(current, next) >= 1) {
                    sorted = false;
                    Swap(array, currentIdx, currentIdx + 1);
                }
            }
        }

        void Swap(T[] array, int i, int j) {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}