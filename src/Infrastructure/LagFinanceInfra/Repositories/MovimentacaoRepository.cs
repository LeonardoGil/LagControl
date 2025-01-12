using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class MovimentacaoRepository : BaseRepository<LagFinanceDbContext, Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
