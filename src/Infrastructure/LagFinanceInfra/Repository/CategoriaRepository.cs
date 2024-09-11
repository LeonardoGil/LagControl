using LagFinanceDomain.Domain;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LagFinanceDbContext context)
        {
            _context = context;
        }
    }
}
