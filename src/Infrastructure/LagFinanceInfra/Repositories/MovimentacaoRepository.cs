using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
