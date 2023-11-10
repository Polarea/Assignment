using ReverseLinq.Data;
using ReverseLinq.Models;

using TempdbContext context = new();

context.Customers.Add(new Customer{ FirstName = "Jessica", LastName = "Alba"});
context.SaveChanges();

foreach (Customer c in context.Customers)
{
    Console.WriteLine($"Name: {c.FirstLast}");
}
