using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.CryptocurrencyDTOs
{
    public class CryptocurrencyPriceDto
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
