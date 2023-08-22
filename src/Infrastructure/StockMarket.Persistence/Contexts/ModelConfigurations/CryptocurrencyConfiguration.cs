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
    public class CryptocurrencyConfiguration : IEntityTypeConfiguration<Cryptocurrency>
    {
        public void Configure(EntityTypeBuilder<Cryptocurrency> builder)
        {
            builder.HasData(GenareteSeedData(25));
        }


        private static List<Cryptocurrency> GenareteSeedData(int count)
        {
            List<Cryptocurrency> cryptocurrencies = new();
            for (int i = 1; i < count + 1; i++)
                cryptocurrencies.Add(new()
                {
                    Id= i,
                    Name=$"Cryptocurrency-{i}",
                    Stock=i*50,
                    UnitPrice=i+20,
                    CategoryId=1
                });
            return cryptocurrencies;
        }

    }
}
