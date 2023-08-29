using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Exceptions
{
    public class UpdateFailedException:Exception
    {
        public UpdateFailedException()
        {
        }
        public UpdateFailedException(Type type) : base($"{type.Name} - Güncelleme Hatası !")
        {
        }
        public UpdateFailedException(string message) : base(message)
        {
        }
        public UpdateFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
