using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleProject
{
    public class Figure
    {
        public readonly double pi = Math.PI;
         
    }
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class Circle : Figure
    {
        public double Radius { get; set; }
    }
    static class PatternMatching
    {
        static void PrintArea(Figure figure)
        {
            switch (figure)
            {
                case Rectangle r when r.Width == r.Height:
                    Console.WriteLine("The area of the square is " + r.Width * r.Height);
                    break;
                case Rectangle r:
                    Console.WriteLine("The area is " + r.Width * r.Height);
                    break;
                case Circle c:
                    Console.WriteLine("The area is " + c.Radius * figure.pi);
                    break;
            }
            
            
        }
        static void Main()
        {
            Circle c = new Circle { Radius = 25.5};
            Rectangle r = new Rectangle { Height=6.5, Width= 10.12};
            Rectangle r1 = new Rectangle { Height = 5, Width=5 };
            PrintArea(c);
            PrintArea(r);
            PrintArea(r1);
        }
    }
} 
