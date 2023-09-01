using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Domain.Entities;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Contexts.ModelConfigurations
{
    public class CryptocurrencyWalletConfiguration : IEntityTypeConfiguration<CryptocurrencyWallet>
    {
        public void Configure(EntityTypeBuilder<CryptocurrencyWallet> builder)
        {
            builder.HasKey(x => x.UserId);

            builder
                .HasMany(x => x.WalletItems)
                .WithOne(x => x.CryptocurrencyWallet)
                .HasForeignKey(x=>x.CryptocurrencyWalletId);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.CryptocurrencyWallet)
                .HasForeignKey<CryptocurrencyWallet>(x=>x.UserId);
        }
    }
}
