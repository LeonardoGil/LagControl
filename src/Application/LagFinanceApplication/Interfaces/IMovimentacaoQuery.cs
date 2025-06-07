using LagFinanceApplication.Models.Movimentacoes;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoQuery
    {
        IList<MovimentacaoGridModel> ListarMovimentacao(ListarMovimentacaoQueryModel query);

        IList<MovimentacaoGridModel> ListarUltimasMovimentacoes(ListarUltimasMovimentacoesQueryModel query);
    }
}
