using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class Cryptocurrency: BaseEntity
    {
        public Cryptocurrency()
        {
            CryptocurrencyPrices=new HashSet<CryptocurrencyPrice>();
        }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<CryptocurrencyPrice> CryptocurrencyPrices { get; set; }
    }
}
