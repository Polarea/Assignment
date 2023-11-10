using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleProject
{
    static class DeconstructorDemo
    {
        static void Main()
        {
            Class1 cl = new Class1("John", 40, 2000, "Boston");
            var (name,age, salary, city) = cl;
            Console.WriteLine(name + " " + age + " " + salary + " " + city);
            void CountItems(params int[] items) // Local Method
            {
                int sum = 0;
                foreach (var item in items)
                {
                    sum += item;
                }
                Console.WriteLine(sum);
            }
            CountItems(12,24,48,60);
            void AddItems(dynamic x, dynamic y) // Local Method
            {
                Console.WriteLine(x + y);
            }
            AddItems(5, 10);
            AddItems("Pure", "Reason");

        }
    }
}
