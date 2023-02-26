namespace Course.Chapter3Searching; 

public static class Test {
    public static void Start() {
        var table = new SimpleTable<int, Customer>();

        var customer = new Customer {
            Id = 12328823,
            Name = "DIMA HOSPODI",
            Value = 3
        };
        table.Add(customer.Id, customer);
    }

    private class Customer {
        public int Id;
        public string Name;
        public int Value;
    }
}