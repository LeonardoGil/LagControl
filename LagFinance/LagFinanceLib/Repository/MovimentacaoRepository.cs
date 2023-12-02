using LagFinanceLib.Database;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;

namespace LagFinanceLib.Repository
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(LagFinanceDbContext context) : base(context)
        {
        }
    }
}
