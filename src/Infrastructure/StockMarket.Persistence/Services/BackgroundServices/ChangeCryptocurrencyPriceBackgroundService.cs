using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Persistence.Contexts;
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

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            Random random = new();
            using var scope = _service.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<StockMartketDbContext>();
            db.Cryptocurrencies.Include(x=>x.CryptocurrencyCurrentPrice).Include(x => x.Category).ToList().ForEach(x =>
             {
                 //x.UnitPrice = x.UnitPrice *= Convert.ToDecimal((random.NextDouble() + 0.5).ToString("0.00"));
                 db.CryptocurrencyPastPrices.Add(new() { CryptocurrencyId = x.Id, Price = x.CryptocurrencyCurrentPrice.Price });
                 x.CryptocurrencyCurrentPrice.Price *= Convert.ToDecimal((random.NextDouble() + 0.5).ToString("0.00"));
             });
            db.SaveChanges();
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
