using System.Security.Cryptography;
using System.Linq;

namespace LinqProject
{
    internal class LinqObj
    {
        int[] arr = { 12, 62, 43, 85, 25, 65 };
        static void Main(string[] args)
        {
            LinqObj obj = new LinqObj();
            var newArr = from i in obj.arr where i>40 orderby i select i;
            foreach (var i in newArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}