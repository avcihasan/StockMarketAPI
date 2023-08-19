using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking=true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> func, bool tracking = true);
        Task<T> GetAsync(int id, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> func, bool tracking = true);
        Task<bool> CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
        Task CreateRangeAsync(params T[] entities);
        bool Update(T entity);
        void RemoveRange(params T[] entities);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveAsync(Expression<Func<T, bool>> func);
        Task RemoveRangeAsync(params int[] ids);


    }
}
