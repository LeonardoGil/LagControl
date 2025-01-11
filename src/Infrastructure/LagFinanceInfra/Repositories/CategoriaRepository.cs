using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
