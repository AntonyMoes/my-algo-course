namespace Course.Chapter1Basics;

public class Analysis {
    public static void Test() {
        var array = new int[10];
        for (var i = 0; i < array.Length; i++) {
            array[i] = i;
        }


        const int target = 9;
        var position = -1;

        // simple
        for (var i = 0; i < array.Length; i++) { // N
            if (array[i] == target) { // 1
                position = i; // 0.2
                break;
            }
        }
        // O(N * 1 + 0.2) -> O(N)
        // O(1)

        // binary
        var startIdx = 0;
        var endIdx = array.Length - 1;
        do {
            var middle = (startIdx + endIdx) / 2;
            var middleElement = array[middle]; //
            if (middleElement == target) {
                position = middle;
                break;
            }

            if (target < middleElement) {
                endIdx = middle - 1;
            } else {
                startIdx = middle + 1;
            }
        } while (startIdx <= endIdx);
        // O(log(2)N + 1) -> O(log(2)N) -> O(log(N))
        // O(1)

        Console.WriteLine(position);
        
        //
    }
}