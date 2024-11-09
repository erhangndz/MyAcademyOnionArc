using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;
using Product.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Product.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OnionContext _context;

        public Repository(OnionContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await GetByIdAsync(id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter=null, Expression<Func<T, object>>? include=null)
        {
            IQueryable<T> values = _context.Set<T>();

            if (filter != null)
            {
               values = values.Where(filter);
            }
            if (include != null)
            {
                values = values.Include(include);
            }

            return await values.ToListAsync();
        
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
