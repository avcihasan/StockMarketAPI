using Microsoft.EntityFrameworkCore;
using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> func, bool tracking = true);
        IQueryable<T> GetAll(params string[] includes);
        Task<T> GetAsync(string id, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> func, bool tracking = true);
        Task<bool> CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
        Task CreateRangeAsync(params T[] entities);
        bool Update(T entity);
        Task RemoveRangeAsync(params string[] ids);
        Task<bool> RemoveAsync(string id);

        bool Any(Expression<Func<T, bool>> func);

    }
}
