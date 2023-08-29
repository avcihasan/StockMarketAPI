﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException():base("Şifre veya kullanıcı adı hatalı !")
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
