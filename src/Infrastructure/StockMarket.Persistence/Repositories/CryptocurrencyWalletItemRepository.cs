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
    public class CryptocurrencyWalletItemRepository : GenericRepository<CryptocurrencyWalletItem>, ICryptocurrencyWalletItemRepository
    {
        public CryptocurrencyWalletItemRepository(StockMartketDbContext stockMartketDbContext) : base(stockMartketDbContext)
        {
        }
    }
}
