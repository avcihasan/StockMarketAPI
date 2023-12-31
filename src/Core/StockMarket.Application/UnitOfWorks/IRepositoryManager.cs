﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockMarket.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.UnitOfWorks
{
    public interface  IRepositoryManager
    {
        public ICryptocurrencyRepository CryptocurrencyRepository { get;}
        public ICategoryRepository CategoryRepository { get; }
        public ICryptocurrencyWalletItemRepository CryptocurrencyWalletItemRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
