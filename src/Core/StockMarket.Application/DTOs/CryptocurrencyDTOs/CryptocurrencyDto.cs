using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.CryptocurrencyDTOs
{
    public class CryptocurrencyDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public List<CryptocurrencyPriceDto> CryptocurrencyPrices { get; set; }

    }
}
