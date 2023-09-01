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
    public class CryptocurrencyPastPriceConfiguration : IEntityTypeConfiguration<CryptocurrencyPastPrice>
    {
        public void Configure(EntityTypeBuilder<CryptocurrencyPastPrice> builder)
        {
            //builder.HasData(GenareteSeedData(25));
        }

        //private static List<CryptocurrencyPrice> GenareteSeedData(int count)
        //{
        //    List<CryptocurrencyPrice> cryptocurrencyPrices = new();
        //    for (int i = 0; i < count - 1; i++)
        //    {
        //        cryptocurrencyPrices.Add(new()
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            CryptocurrencyId = CryptocurrencyConfiguration.GetCryptocurrenyIds()[i],
        //            Date = DateTime.Now,
        //            Price = 100
        //        });
        //    }
               
        //    return cryptocurrencyPrices;
        //}
    }
}
