using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using StockMarket.Domain.Identity;
using StockMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services
{
    public class WalletService : IWalletService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly DbSet<Wallet> _wallet;
        readonly DbSet<CryptocurrencyWallet> _cryptocurrencyWallet;

        public WalletService(IRepositoryManager repositoryManager, StockMartketDbContext stockMartketDbContext)
        {
            _wallet = stockMartketDbContext.Set<Wallet>();
            _cryptocurrencyWallet = stockMartketDbContext.Set<CryptocurrencyWallet>();
            _repositoryManager = repositoryManager;
        }


        public async Task CreateCryptocurrencyWalletAsync(string userId)
        {
            EntityEntry entityEntry = await _cryptocurrencyWallet.AddAsync(new() { UserId = userId });
            await _repositoryManager.SaveAsync();
            entityEntry.State = EntityState.Detached;
        }

        public async Task CreateWalletAsync(string userId, decimal walletValue)
        {
           EntityEntry entityEntry= await _wallet.AddAsync(new() { UserId=userId,Value=walletValue});
            await _repositoryManager.SaveAsync();

            entityEntry.State = EntityState.Detached;
        }
    }
}
