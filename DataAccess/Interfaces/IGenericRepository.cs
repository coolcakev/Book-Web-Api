using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetFiltered(SortingModel filteringModel, Expression<Func<T, bool>> filter = null,
             Expression<Func<T, object>> include = null);
        Task<List<T>> GetAll();
        ValueTask<T> GetById(object id);
        Task<T> GetByIdWithInclude(object id, params Expression<Func<T, object>>[] include);
        Task Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task Save();
    }
}
