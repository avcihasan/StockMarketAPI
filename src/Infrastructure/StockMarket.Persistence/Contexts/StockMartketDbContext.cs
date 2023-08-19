using Microsoft.EntityFrameworkCore;
using StockMarket.Domain.Common;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Contexts
{
    public class StockMartketDbContext:DbContext
    {
        public StockMartketDbContext(DbContextOptions<StockMartketDbContext> options):base(options)
        {
        }
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
                if(data is not null)
                    switch (data.State)
                    {
                        case EntityState.Added:
                            data.Entity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            data.Entity.UpdatedDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
