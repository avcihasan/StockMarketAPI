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
    }
}
