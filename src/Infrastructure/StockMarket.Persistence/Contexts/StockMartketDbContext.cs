﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockMarket.Domain.Common;
using StockMarket.Domain.Entities;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Contexts
{
    public class StockMartketDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public StockMartketDbContext(DbContextOptions<StockMartketDbContext> options):base(options)
        {
        }
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<CryptocurrencyPrice> CryptocurrencyPrices { get; set; }
        public DbSet<Category> Categories { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
