using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CategoriaRepository : BaseRepository<LagFinanceDbContext, Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
