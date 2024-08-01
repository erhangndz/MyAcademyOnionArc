using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IProductRepository: IRepository<Domain.Entities.Product>
    {
        Task<List<Domain.Entities.Product>> GetAllProductsWithCategoryAsync();

    }
}
