using StockMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class CryptocurrencyWalletItem:BaseEntity
    {
        public string CryptocurrencyId { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
        public int Quantity { get; set; }

        public string CryptocurrencyWalletId { get; set; }
        public CryptocurrencyWallet CryptocurrencyWallet { get; set; }
    }
}
