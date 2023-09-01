using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockMarket.Domain.Common;
using StockMarket.Domain.Entities;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Contexts
{
    public class StockMartketDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public StockMartketDbContext(DbContextOptions<StockMartketDbContext> options) : base(options)
        {
        }
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<CryptocurrencyPastPrice> CryptocurrencyPastPrices { get; set; }
        public DbSet<CryptocurrencyCurrentPrice> CryptocurrencyCurrentPrices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CryptocurrencyWallet> CryptocurrencyWallets { get; set; }
        public DbSet<CryptocurrencyWalletItem> CryptocurrencyWalletItems { get; set; }
        public DbSet<Wallet> UserWallets { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                                    .HavePrecision(18, 2);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConfigureDatasDate();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            ConfigureDatasDate();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureDatasDate()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => data.Entity.UpdatedDate = DateTime.Now,
                };
            }
        }

    }
}
