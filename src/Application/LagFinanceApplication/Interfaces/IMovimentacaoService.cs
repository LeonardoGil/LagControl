using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        void AdicionarDespesa(AdicionarMovimentacaoModel model);
    }
}
