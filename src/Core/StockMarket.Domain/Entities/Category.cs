using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Cryptocurrency> Cryptocurrencies { get; set; }
    }
}
