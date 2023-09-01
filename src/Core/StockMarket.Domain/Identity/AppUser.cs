using Microsoft.AspNetCore.Identity;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }


        public CryptocurrencyWallet CryptocurrencyWallet { get; set; }
        public Wallet Wallet { get; set; }


    }
}

