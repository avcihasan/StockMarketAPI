using StackExchange.Redis;
using StockMarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services
{
    public class RedisService : IRedisService
    {
        public ConnectionMultiplexer ConnectionMultiplexer { get; private set; }
        public IDatabase Database { get; private set; }
        public RedisService(string options)
        {
            ConnectionMultiplexer = ConnectionMultiplexer.Connect(options);
            Database = ConnectionMultiplexer.GetDatabase(0);
        }
    }
}
