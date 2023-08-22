using Microsoft.Extensions.DependencyInjection;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Persistence.Services;
using StockMarket.Persistence.UnitOfWorks;

namespace StockMarket.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryManager, RepositoryManager>();
            service.AddScoped<IServiceManager, ServiceManager>();

            service.AddScoped<ICryptocurrencyService, CryptocurrencyService>();
            service.AddScoped<ICategoryService , CategoryService>();

        }
    }
}
