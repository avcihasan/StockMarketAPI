using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.UnitOfWorks
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(ICryptocurrencyService cryptocurrencyService)
        {
            CryptocurrencyService = cryptocurrencyService;
        }

        public ICryptocurrencyService CryptocurrencyService { get; private set; }
    }
}
