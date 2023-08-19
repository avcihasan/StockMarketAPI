using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockMarket.Application.Repositories;
using StockMarket.Domain.Common;
using StockMarket.Persistence.Contexts;
using System;
using System.Linq.Expressions;

namespace StockMarket.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly DbSet<T> _dbSet;

        public GenericRepository(StockMartketDbContext stockMartketDbContext)
        {
            _dbSet = stockMartketDbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).State == EntityState.Added;

        public async Task CreateRangeAsync(List<T> entities)
           => await _dbSet.AddRangeAsync(entities);

        public async Task CreateRangeAsync(params T[] entities)
           => await _dbSet.AddRangeAsync(entities);

        public void RemoveRange(params T[] entities)
           => _dbSet.RemoveRange(entities);

        public bool Remove(T entity)
            => _dbSet.Remove(entity).State == EntityState.Deleted;

        public async Task<bool> RemoveAsync(int id)
            => Remove(await GetAsync(id));

        public async Task<bool> RemoveAsync(Expression<Func<T, bool>> func)
            => Remove(await GetAsync(func));

        public async Task RemoveRangeAsync(params int[] ids)
        {
            foreach (int id in ids)
              await RemoveAsync(id);
        }

        public async Task<T> GetAsync(int id, bool tracking = true)
            => await GetAll(tracking).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> func, bool tracking = true)
            => await GetAll(tracking).FirstOrDefaultAsync(func);

        public IQueryable<T> GetAll(bool tracking = true)
            => Track(_dbSet.AsQueryable(), tracking);

        public IQueryable<T> GetAll(Expression<Func<T, bool>> func, bool tracking = true)
            => Track(_dbSet.Where(func), tracking);

        public bool Update(T entity)
            => _dbSet.Update(entity).State == EntityState.Modified;


        private IQueryable<T> Track(IQueryable<T> query,bool tracking)
        {
            if (!tracking)
                query.AsNoTracking();
            return query;
        }
    }
}
