using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Giriş Hatası!")
        {
        }
        public LoginException(string message) : base(message)
        {
        }
        public LoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
