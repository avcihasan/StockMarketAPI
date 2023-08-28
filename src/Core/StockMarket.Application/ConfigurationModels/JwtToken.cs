using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.ConfigurationModels
{
    public class JwtToken
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
    }
}
