using LagFinanceApplication.Models.Movimentacoes;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoQuery
    {
        IList<MovimentacaoModel> ListarUltimasMovimentacoes(ListarUltimasMovimentacoesQueryModel query);
    }
}
