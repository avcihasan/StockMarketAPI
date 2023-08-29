using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Exceptions
{
    public class RemoveFailedException:Exception
    {
        public RemoveFailedException()
        {
        }
        public RemoveFailedException(Type type) : base($"{type.Name} - Silme Hatası !")
        {
        }
        public RemoveFailedException(string message) : base(message)
        {
        }
        public RemoveFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
