using StockMarket.Domain.Common;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class CryptocurrencyWallet
    {
        public ICollection<CryptocurrencyWalletItem> WalletItems { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public CryptocurrencyWallet()
        {
            WalletItems = new HashSet<CryptocurrencyWalletItem>();
        }
    }
}
