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
            CryptocurrencyPrices = new HashSet<CryptocurrencyPastPrice>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public CryptocurrencyCurrentPrice CryptocurrencyCurrentPrice { get; set; }

        public ICollection<CryptocurrencyPastPrice> CryptocurrencyPrices { get; set; }
    }
}
