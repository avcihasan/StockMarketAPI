using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class CryptocurrencyPastPrice:BaseEntity
    {
        [NotMapped]
        public new DateTime UpdatedDate { get; set; }
        public decimal Price { get; set; }

        public string CryptocurrencyId { get; set; }
    }
}
