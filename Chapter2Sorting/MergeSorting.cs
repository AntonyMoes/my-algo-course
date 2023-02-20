namespace Course.Chapter2Sorting; 

public class MergeSorting : ISorting {
    public void Sort<T>(ref T[] array, Comparison<T> comparison) {
        if (Divide(array, out var arr1, out var arr2)) {
            Sort(ref arr1, comparison);
            Sort(ref arr2, comparison);
            array = Merge(arr1, arr2, comparison);
        }
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
        // for (var i = 0; i < length; i++) {
        //     if (pointer2 < arr2.Length && pointer1 < arr1.Length) {
        //         if (comparison(arr1[pointer1], arr2[pointer2]) >= 1) {
        //             result[i] = arr2[pointer2];
        //             pointer2++;
        //         } else {
        //             result[i] = arr1[pointer1];
        //             pointer1++;
        //         }
        //     } else {
        //         if (pointer2 > arr2.Length) {
        //             result[i] = arr1[pointer1];
        //             pointer1++;
        //         } else {
        //             result[i] = arr2[pointer2];
        //             pointer2++;
        //         }
        //     }
        // }

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