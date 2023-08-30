using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services.BackgroundServices
{
    public class ChangeCryptocurrencyPriceBackgroundService : IHostedService, IDisposable
    {
        Timer _timer;
        readonly IServiceProvider _service;

        public ChangeCryptocurrencyPriceBackgroundService(IServiceProvider service)
        {
            _service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            Random random = new();
            using var scope = _service.CreateScope();
            var repositoryManager = scope.ServiceProvider.GetRequiredService<IRepositoryManager>();
            repositoryManager.CryptocurrencyRepository.GetAll().ToList().ForEach(x =>
            {
                x.UnitPrice *= Convert.ToDecimal((random.NextDouble() + 0.5).ToString("0.00"));
                x.CryptocurrencyPrices.Add(new() { CryptocurrencyId = x.Id, Date = DateTime.Now, Price = x.UnitPrice });
            });
            //repositoryManager.Save();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
      
    }
}
