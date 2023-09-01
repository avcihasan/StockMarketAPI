using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface IWalletService
    {
        Task CreateWalletAsync(string userId,decimal walletValue);
        Task CreateCryptocurrencyWalletAsync(string userId);
    }
}
