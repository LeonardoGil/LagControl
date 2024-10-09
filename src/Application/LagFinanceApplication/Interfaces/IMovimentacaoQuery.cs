using LagFinanceApplication.Models.Movimentacoes;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoQuery
    {
        IList<MovimentacaoModel> ListarMovimentacao(ListarMovimentacaoQueryModel query);

        IList<MovimentacaoModel> ListarUltimasMovimentacoes(ListarUltimasMovimentacoesQueryModel query);
    }
}
