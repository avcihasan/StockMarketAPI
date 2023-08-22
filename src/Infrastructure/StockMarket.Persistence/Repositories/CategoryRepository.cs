using StockMarket.Application.Repositories;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Contexts;

namespace StockMarket.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockMartketDbContext stockMartketDbContext) : base(stockMartketDbContext)
        {
        }
    }
}
