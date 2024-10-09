using LagFinanceApplication.Models.Movimentacoes;

namespace LagFinanceApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        void Adicionar(AdicionarMovimentacaoModel model);

        void Editar(EditarMovimentaoModel model);

        void Excluir(Guid movimentacaoId);

        void ConfirmarPendente(ConfirmarMovimentacaoPendenteModel model);
    }
}
