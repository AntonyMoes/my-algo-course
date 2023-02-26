namespace Course.Chapter2Sorting;

public class Sorter {
    private readonly ISorting _sorting;

    public Sorter(ISorting sorting) {
        _sorting = sorting;
    }

    public void Sort<T>(ref T[] collection, Comparison<T> comparison = null) {
        comparison ??= Comparer<T>.Default.Compare;

        _sorting.Sort(ref collection, comparison);
    }

    // static
    
    private static int[] GenerateArray(int size) {
        const int min = 0;
        const int max = 100;

        var random = new Random();
        return Enumerable.Range(0, size)
            .Select(_ => random.Next(min, max))
            .ToArray();
    }

    private static void Log(int[] array) {
        Console.Out.WriteLine(string.Join(", ", array.Select(el => el.ToString()).ToArray()));
    }

    private static bool IsSorted(int[] array, Comparison<int> comparison = null) {
        comparison ??= Comparer<int>.Default.Compare;
        
        for (var i = 1; i < array.Length; i++) {
            var current = array[i];
            var previous = array[i - 1];
            if (comparison(previous, current) >= 1) {
                return false;
            }
        }

        return true;
    }

    public static void TestSorting() {
        // var sorter = new Sorter(new MergeSortingCycle());
        var heap = new Heap<int>();
        var array = GenerateArray(15);

        Log(array);
        Console.Out.WriteLine(IsSorted(array));
        foreach (var i in array) {
            heap.Add(i);
        }
        array = Enumerable.Range(0, array.Length).Select(_ => heap.Remove()).ToArray();
        // sorter.Sort(ref array);
        Log(array);
        Console.Out.WriteLine(IsSorted(array));
        
    }
}