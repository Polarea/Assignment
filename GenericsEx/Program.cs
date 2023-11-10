namespace GenericsEx

    // Implementation of IComparable<> and IComparer<> interfaces which are used to consume Sort method in List<> with complex types.
{
    internal class Customer: IComparable<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    
        static void Main(string[] args)
        {
            Customer c1 = new Customer { Name = "Ali", Address = "Broad Street", City = "Washington" };
            Customer c2 = new Customer { Name = "Allen", Address = "Cross Street", City = "New York" };
            List<Customer> list = new List<Customer>() { c1, c2};
            CompareCustomer cc = new CompareCustomer();
            list.Sort(cc);
            foreach (Customer c in list)
            {
                Console.WriteLine(c.Name + " " + c.Address + " " + c.City);
            }
        }

        // Implementation of IComparable<> interface's method
        public int CompareTo(Customer? other)
        {
            if (this.Name.Length > other.Name.Length)
            {
                return 1;
            }
            else if(this.Name.Length < other.Name.Length)
            {
                return -1;
            }
            else { return 0; }
        }
    }

    // In case of consuming someone other's class, inherit a class from the required class and IComparer<> interface is applied
    // on the inherited class

    class CompareCustomer : IComparer<Customer>
    {
        public int Compare(Customer? x, Customer? y)
        {
            if(x?.City.Length > y?.City.Length)
            {
                return 1;
            }
            else if (x?.City.Length < y?.City.Length)
            {
                return -1;
            }
            else return 0;
        }
    }
}