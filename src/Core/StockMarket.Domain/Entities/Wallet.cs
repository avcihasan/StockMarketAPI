using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class Wallet
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal Value { get; set; }
    }
}
