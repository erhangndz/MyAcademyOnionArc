using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistance.Context
{
    public class OnionContext: DbContext
    {

        public OnionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Domain.Entities.Product> Products { get; set; } 
        public DbSet<Customer> Customers { get; set; } 

    }
}
