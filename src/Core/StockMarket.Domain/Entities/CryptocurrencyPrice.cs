using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class CryptocurrencyPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public int CryptocurrencyId { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
    }
}
