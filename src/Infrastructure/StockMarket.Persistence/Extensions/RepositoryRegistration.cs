using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockMarket.Application.Repositories;
using StockMarket.Application.Services;
using StockMarket.Domain.Common;
using StockMarket.Persistence.Contexts;
using StockMarket.Persistence.Repositories;
using StockMarket.Persistence.Repositories.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Extensions
{
    public static class RepositoryRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICryptocurrencyRepository>(sp =>
            {
                IRedisService redisService = sp.GetRequiredService<IRedisService>();
                StockMartketDbContext stockMartketDbContext = sp.GetRequiredService<StockMartketDbContext>();
                CryptocurrencyRepository cryptocurrencyRepository = new(stockMartketDbContext);

                return new CryptocurrencyRedisRepository(cryptocurrencyRepository,redisService);
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

    }
}