using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
    }
}
