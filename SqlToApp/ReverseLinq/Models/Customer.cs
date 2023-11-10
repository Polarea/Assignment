using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinq.Models
{
    public partial class Customer
    {
        public string FirstLast 
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
