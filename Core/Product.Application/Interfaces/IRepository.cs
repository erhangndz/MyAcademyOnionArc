using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter=null,Expression<Func<T,object>>? include=null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


    }
}
