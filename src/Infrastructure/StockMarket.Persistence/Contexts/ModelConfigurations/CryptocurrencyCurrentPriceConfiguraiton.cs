using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Contexts.ModelConfigurations
{
    public class CryptocurrencyCurrentPriceConfiguraiton : IEntityTypeConfiguration<CryptocurrencyCurrentPrice>
    {
        public void Configure(EntityTypeBuilder<CryptocurrencyCurrentPrice> builder)
        {
            builder.HasKey(x => x.CryptocurrencyId);

            builder
                .HasOne(x => x.Cryptocurrency)
                .WithOne(x => x.CryptocurrencyCurrentPrice)
                .HasForeignKey<CryptocurrencyCurrentPrice>(x => x.CryptocurrencyId);
        }
    }
}
