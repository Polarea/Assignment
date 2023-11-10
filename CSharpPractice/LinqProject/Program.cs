using LinqProject.Data;
using LinqProject.Models;



namespace LinqProject
{
    static class Program
    {
        static void Main(string[] args)
        {
           using ShopContext context = new ShopContext();
            var veggieSpecial = context.Products
                .Where(p => p.Name == "Veggie Special Pizza")
                .FirstOrDefault();
            if (veggieSpecial is Product)
            {
                context.Remove(veggieSpecial);
            }
            context.SaveChanges();

            var products = context.Products
                .Where(p => p.Price > 10.00M)
                .OrderBy(p => p.Name);
            foreach (Product p in products)
            {
                Console.WriteLine($"   Id:   {p.Id}");
                Console.WriteLine($" Name:   {p.Name}");
                Console.WriteLine($"Price:   {p.Price}");
                Console.WriteLine(new string('-', 20));
            }
        }
        
    }
}
