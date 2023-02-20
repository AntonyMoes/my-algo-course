namespace Course.Chapter2Sorting; 

public class MergeSortingCycle : ISorting {
    public void Sort<T>(ref T[] array, Comparison<T> comparison) {
        var divide = new Stack<T[]>();
        var merge = new Stack<T[]>();
        divide.Push(array);

        while (divide.Count != 0) {
            var current = divide.Pop();
            if (Divide(current, out var newArr1, out var newArr2)) {
                divide.Push(newArr2);
                divide.Push(newArr1);
            } else {
                merge.Push(current);
            }
        }

        while (merge.Count > 1) {
            var arr1 = merge.Pop();
            var arr2 = merge.Pop();
            var result = Merge(arr1, arr2, comparison);
            merge.Push(result);
        }

        array = merge.Pop();
    }

    private bool Divide<T>(T[] array, out T[] arr1, out T[] arr2) {
        if (array.Length <= 1) {
            arr1 = null;
            arr2 = null;
            return false;
        }

        var middle = array.Length / 2;
        arr1 = array.Take(middle).ToArray();
        arr2 = array.Skip(middle).ToArray();
        return true;
    }

    private T[] Merge<T>(T[] arr1, T[] arr2, Comparison<T> comparison) {
        var length = arr1.Length + arr2.Length;
        var result = new T[length];

        var pointer1 = 0;
        var pointer2 = 0;

        while (pointer2 < arr2.Length && pointer1 < arr1.Length) {
            if (comparison(arr1[pointer1], arr2[pointer2]) >= 1) {
                result[ResultPointer()] = arr2[pointer2];
                pointer2++;
            } else {
                result[ResultPointer()] = arr1[pointer1];
                pointer1++;
            }
        }

        while (pointer2 < arr2.Length) {
            result[ResultPointer()] = arr2[pointer2];
            pointer2++;
        }

        while (pointer1 < arr1.Length) {
            result[ResultPointer()] = arr1[pointer1];
            pointer1++;
        }

        return result;

        int ResultPointer() => pointer1 + pointer2;
    }
}