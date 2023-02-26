namespace Course.Chapter3Searching; 

public class Hasher {
    public int Hash(int value) {
        return value;
    }

    public int Hash(string value) {
        return value.Length;
    }
}