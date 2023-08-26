using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using StockMarket.Application.Repositories;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Repositories.Caching
{
    public class CryptocurrencyRedisRepository : ICryptocurrencyRepository
    {
        const string key = "cryptocurrencies";
        readonly ICryptocurrencyRepository _repository;
        readonly IDatabase _database;

        public CryptocurrencyRedisRepository(ICryptocurrencyRepository repository, IRedisService redis)
        {
            _repository = repository;
            _database = redis.Database;
        }

        public bool Any(Expression<Func<Cryptocurrency, bool>> func)
        {
            IQueryable<Cryptocurrency> cryptocurrencies;
            if (!_database.KeyExists(key))
                cryptocurrencies = RedisSet();
            else
                cryptocurrencies = GetAll();
            return cryptocurrencies.FirstOrDefault(func) is null ? false : true;
        }

        public async Task<bool> CreateAsync(Cryptocurrency entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public Task CreateRangeAsync(List<Cryptocurrency> entities)
        {
            entities.ForEach(async x =>
            {
                await CreateAsync(x);
            });
            return Task.CompletedTask;
        }

        public async Task CreateRangeAsync(params Cryptocurrency[] entities)
            => await CreateRangeAsync(entities.ToList());

        public IQueryable<Cryptocurrency> GetAll(bool tracking = true)
        {
            if (!_database.KeyExists(key))
                return RedisSet();
            List<Cryptocurrency> cryptocurrencies = new();
            foreach (var item in _database.HashGetAll(key))
                cryptocurrencies.Add(JsonSerializer.Deserialize<Cryptocurrency>(item.Value));

            return cryptocurrencies.AsQueryable();
        }

        public IQueryable<Cryptocurrency> GetAll(Expression<Func<Cryptocurrency, bool>> func, bool tracking = true)
            => GetAll().Where(func);

        public IQueryable<Cryptocurrency> GetAll(params string[] includes)
            => _repository.GetAll(includes);

        public async Task<Cryptocurrency> GetAsync(int id, bool tracking = true)
        {
            if (!_database.KeyExists(key))
                return await RedisSet().FirstOrDefaultAsync(x => x.Id == id);

            var cryptocurrency = await _database.HashGetAsync(key, id);
            return cryptocurrency.HasValue  ? JsonSerializer.Deserialize<Cryptocurrency>(cryptocurrency) : await RedisSet().FirstOrDefaultAsync(x => x.Id == id);
        }

        public  Task<Cryptocurrency> GetAsync(Expression<Func<Cryptocurrency, bool>> func, bool tracking = true)
            =>  Task.FromResult(GetAll().FirstOrDefault(func));

        public async Task<bool> RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
            return await _database.HashDeleteAsync(key, id);
        }
        public async Task RemoveRangeAsync(params int[] ids)
        {
            foreach (var item in ids)
                await RemoveAsync(item);
        }

        public bool Update(Cryptocurrency entity)
        {
            RemoveAsync(entity.Id).Wait();
            _repository.Update(entity);
            return CreateAsync(entity).Result;
        }

        private IQueryable<Cryptocurrency> RedisSet()
        {
            var r = _repository.GetAll();

            r.ToList().ForEach(x =>
                       {
                           _database.HashSet(key, x.Id, JsonSerializer.Serialize(x));
                       });
            return r.AsQueryable();
        }
    }
}
 