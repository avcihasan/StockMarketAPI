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
        Task RemoveRangeAsync(params int[] ids);
        Task<bool> RemoveAsync(int id);

        bool Any(Expression<Func<T, bool>> func);

    }
}
