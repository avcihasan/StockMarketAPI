using StockMarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.UnitOfWorks
{
    public interface IServiceManager
    {
        public ICryptocurrencyService CryptocurrencyService { get; }
        public ICategoryService CategoryService { get; }
    }
}
