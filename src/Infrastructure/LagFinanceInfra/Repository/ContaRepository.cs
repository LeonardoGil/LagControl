using LagFinanceDomain.Domain;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(LagFinanceDbContext context)
        {
            _context = context;
        }
    }
}
