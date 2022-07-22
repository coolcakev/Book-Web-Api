using DataAccess.Interfaces;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{


    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationContext _context { get; set; }
        private DbSet<T> table = null;
        public GenericRepository(ApplicationContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public Task<List<T>> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = table;
            query = query.Where(filter);
            return query.ToListAsync();
        }
        public Task<List<T>> GetAll()
        {
            return table.ToListAsync();
        }
        public ValueTask<T> GetById(object id)
        {
            return table.FindAsync(id);
        }
        public Task<T> GetByIdWithInclude(object id,params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.SingleOrDefaultAsync(x => x.GetType().GetProperty("Id") == id);
        }
        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            table.Remove(obj);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetFiltered(SortingModel filteringModel, Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var isCorrectProperty = typeof(T).GetProperties().Any(x => x.Name == filteringModel.Name);
            if (filteringModel.SortOrder == SortOrder.Ask && isCorrectProperty)
            {
                query = query.OrderBy(x => x.GetType().GetProperty(filteringModel.Name).GetValue(x));
            }
            else if (isCorrectProperty)
            {
                query = query.OrderByDescending(x => x.GetType().GetProperty(filteringModel.Name).GetValue(x));
            }

            query = query.Skip(filteringModel.Page * filteringModel.Count);
            if (filteringModel.Count != 0)
            {
                query = query.Take(filteringModel.Count);
            }

            return query.ToListAsync();
        }
    }
}
