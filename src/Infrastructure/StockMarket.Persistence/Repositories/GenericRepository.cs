using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockMarket.Application.Repositories;
using StockMarket.Domain.Common;
using StockMarket.Persistence.Contexts;
using System;
using System.Linq.Expressions;

namespace StockMarket.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly StockMartketDbContext _stockMartketDbContext;

        public GenericRepository(StockMartketDbContext stockMartketDbContext)
        {
            _stockMartketDbContext = stockMartketDbContext;
            _dbSet = stockMartketDbContext.Set<T>();
        }

        public virtual async Task<bool> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).State == EntityState.Added;

        public virtual async Task CreateRangeAsync(List<T> entities)
           => await _dbSet.AddRangeAsync(entities);

        public virtual async Task CreateRangeAsync(params T[] entities)
           => await _dbSet.AddRangeAsync(entities);

        public virtual async Task RemoveRangeAsync(params string[] ids)
        {
            foreach (string id in ids)
                await RemoveAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(string id)
            => _dbSet.Remove(await GetAsync(id)).State == EntityState.Deleted;
        public virtual async Task<T> GetAsync(string id, bool tracking = true)
            => await GetAll(tracking).FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> func, bool tracking = true)
            => await GetAll(tracking).FirstOrDefaultAsync(func);

        public virtual IQueryable<T> GetAll(bool tracking = true)
            => Track(_dbSet.AsQueryable(), tracking);

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> func, bool tracking = true)
            => Track(_dbSet.Where(func), tracking);

        public virtual bool Update(T entity)
            => _dbSet.Update(entity).State == EntityState.Modified;


        public virtual bool Any(Expression<Func<T, bool>> func)
            => _dbSet.Where(func).AsNoTracking().Any();

        public virtual IQueryable<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = GetAll();
            return query.Include(includes.First());
        }


        private static IQueryable<T> Track(IQueryable<T> query, bool tracking)
        {
            if (!tracking)
                query.AsNoTracking();
            return query;
        }
    }
}
