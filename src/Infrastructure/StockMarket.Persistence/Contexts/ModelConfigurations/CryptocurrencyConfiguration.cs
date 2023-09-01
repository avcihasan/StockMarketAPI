using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockMarket.Persistence.Contexts.ModelConfigurations
{
    public class CryptocurrencyConfiguration : IEntityTypeConfiguration<Cryptocurrency>
    {


        public void Configure(EntityTypeBuilder<Cryptocurrency> builder)
        {
            builder
                .HasIndex(o => o.Code)
                .IsUnique();

            builder.Navigation(x => x.CryptocurrencyCurrentPrice).AutoInclude();

            //builder.HasData(GenareteSeedData(25));

            //builder
            //    .HasMany(x => x.CryptocurrencyPrices)
            //    .WithOne(x => x.Cryptocurrency)
            //    .HasForeignKey(x => x.CryptocurrencyId);
        }


        //private static List<Cryptocurrency> GenareteSeedData(int count)
        //{
        //    List<Cryptocurrency> cryptocurrencies = new();
        //    for (int i = 0; i < count-1; i++)
        //    {
        //        cryptocurrencies.Add(new()
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = $"Cryptocurrency-{i}",
        //            Stock = i * 50,
        //            UnitPrice = 100,
        //            CategoryId = CategoryConfiguration.seedCategoryId,
        //            Code = $"c{i}"
        //        });
        //    }

        //    return cryptocurrencies;
        //}
    }
}
