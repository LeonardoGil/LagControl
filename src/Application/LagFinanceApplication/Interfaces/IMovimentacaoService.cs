using LagFinanceApplication.Models.Movimentacoes;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        void Adicionar(AdicionarMovimentacaoModel model);
    }
}
