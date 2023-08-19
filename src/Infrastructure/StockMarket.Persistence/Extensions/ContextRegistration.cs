using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Extensions
{
    public static class ContextRegistration
    {
        public static void AddStockMarketDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StockMartketDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlCon")));

        }
    }
}
