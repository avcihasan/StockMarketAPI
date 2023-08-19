﻿using StockMarket.Application.Repositories;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.UnitOfWorks
{
    public class RepositoryManager : IRepositoryManager
    {
        readonly StockMartketDbContext _context;

        public RepositoryManager(StockMartketDbContext context, ICryptocurrencyRepository cryptocurrencyRepository)
        {
            _context = context;
            CryptocurrencyRepository = cryptocurrencyRepository;
        }

        public ICryptocurrencyRepository CryptocurrencyRepository { get; private set; }

       

        public void Save()
            => _context.SaveChanges();

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
