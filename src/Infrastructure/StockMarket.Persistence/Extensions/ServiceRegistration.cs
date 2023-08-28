using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Persistence.Services;
using StockMarket.Persistence.Services.BackgroundServices;
using StockMarket.Persistence.UnitOfWorks;

namespace StockMarket.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IRepositoryManager, RepositoryManager>();
            service.AddScoped<IServiceManager, ServiceManager>();

            service.AddScoped<ICryptocurrencyService, CryptocurrencyService>();
            service.AddScoped<ICategoryService , CategoryService>();
            service.AddScoped<IUserService , UserService>();
            service.AddScoped<IAuthService , AuthService>();

            service.AddHostedService<ChangeCryptocurrencyPriceBackgroundService>();


            service.AddSingleton<IRedisService>(sp =>
            {
                return new RedisService(configuration["Redis"]);
            });

        }
    }
}
