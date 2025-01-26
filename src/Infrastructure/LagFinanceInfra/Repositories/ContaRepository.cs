using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class ContaRepository : BaseRepository<LagFinanceDbContext, Conta>, IContaRepository
    {
        public ContaRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
