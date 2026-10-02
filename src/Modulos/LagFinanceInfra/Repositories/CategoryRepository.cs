using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CategoryRepository : BaseRepository<LagFinanceDbContext, Category>, ICategoryRepository
    {
        public CategoryRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}

