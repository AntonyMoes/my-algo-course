namespace Course.Chapter2Sorting; 

public class SelectionSorting : ISorting {
    public void Sort<T>(ref T[] array, Comparison<T> comparison) {
        for (var current = 0; current < array.Length; current++) {

            var indexToSwap = current;
            for (var i = current + 1; i < array.Length; i++) {
                if (comparison(array[indexToSwap], array[i]) >= 1) {
                    indexToSwap = i;
                }
            }

            var temp = array[current];
            array[current] = array[indexToSwap];
            array[indexToSwap] = temp;
        }
    }
}