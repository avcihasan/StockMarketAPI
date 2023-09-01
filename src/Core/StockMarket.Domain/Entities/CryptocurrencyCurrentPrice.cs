using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class CryptocurrencyCurrentPrice
    {
        public decimal Price { get; set; }

        public string CryptocurrencyId { get; set; }
        [JsonIgnore]
        public Cryptocurrency Cryptocurrency { get; set; }
    }
}
