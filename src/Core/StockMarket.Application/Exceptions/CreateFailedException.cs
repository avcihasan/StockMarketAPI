using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Exceptions
{
    public class CreateFailedException : Exception
    {
        public CreateFailedException()
        {
        }
        public CreateFailedException(Type type) : base($"{type.Name} - Oluşturma Hatası !")
        {
        }
        public CreateFailedException(string message) : base(message)
        {
        }
        public CreateFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
