using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockMarket.Application.Repositories;
using StockMarket.Domain.Common;
using StockMarket.Persistence.Repositories;
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
            services.AddScoped<ICryptocurrencyRepository, CryptocurrencyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

    }
}