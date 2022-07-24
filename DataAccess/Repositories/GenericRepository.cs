using DataAccess.Interfaces;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.DynamicLinq;

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
        public Task<T> GetById(object id)
        {
            return table.FindAsync(id).AsTask();
        }
        public Task<dynamic> GetByIdWithInclude(object id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefaultAsync($"c => c.Id == {id}");
        }
        public Task Insert(T obj)
        {
            return table.AddAsync(obj).AsTask();
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
        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<T>> GetFiltered(SortingModel filteringModel, Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);

            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (filteringModel.Name != null)
            {
                query = query.OrderBy($"{filteringModel.Name} {filteringModel.SortOrder}");
            }

            if (filteringModel.Count != 0)
            {
                query = query.Skip(filteringModel.Page * filteringModel.Count).Take(filteringModel.Count);
            }

            return query.ToListAsync();
        }
    }
}
