using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;
using Product.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistance.Repositories
{
    public class ProductRepository : Repository<Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(OnionContext context) : base(context)
        {
        }

        public async Task<List<Domain.Entities.Product>> GetAllProductsWithCategoryAsync()
        {
            return await _context.Products.Include(x=>x.Category).ToListAsync();
        }
    }
}
