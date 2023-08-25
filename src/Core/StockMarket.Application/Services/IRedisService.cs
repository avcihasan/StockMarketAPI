using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface IRedisService
    {
        public  ConnectionMultiplexer ConnectionMultiplexer { get; }
        public IDatabase Database { get;}
    }
}
