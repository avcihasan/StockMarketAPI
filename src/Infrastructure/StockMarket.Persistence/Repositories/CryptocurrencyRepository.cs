using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using StockMarket.Application.Repositories;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Repositories
{
    public class CryptocurrencyRepository : GenericRepository<Cryptocurrency>, ICryptocurrencyRepository
    {
        public CryptocurrencyRepository(StockMartketDbContext stockMartketDbContext) : base(stockMartketDbContext)
        {
        }
        public override async Task<bool> CreateAsync(Cryptocurrency entity)
        {
            if (await base.CreateAsync(entity))
                return (await _stockMartketDbContext.CryptocurrencyCurrentPrices.AddAsync(new() { CryptocurrencyId = entity.Id, Price = entity.UnitPrice})).State == EntityState.Added;
            else 
                return false;
        }
    }
}
