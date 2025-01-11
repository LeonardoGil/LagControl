using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
