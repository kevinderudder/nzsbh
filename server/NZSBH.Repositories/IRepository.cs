using NZSBH.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangesAsync();
        void Update(T entity);
    }
}