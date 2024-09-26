using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        void Adicionar(AdicionarMovimentacaoModel model);
    }
}
