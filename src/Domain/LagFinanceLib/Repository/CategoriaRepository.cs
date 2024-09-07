using LagFinanceLib.Database;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;

namespace LagFinanceLib.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LagFinanceDbContext context)
        {
            _context = context;
        }
    }
}
