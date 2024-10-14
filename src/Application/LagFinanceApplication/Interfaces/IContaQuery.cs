using LagFinanceApplication.Models.Contas;

namespace LagFinanceApplication.Interfaces
{
    public interface IContaQuery
    {
        IList<ContaListaModel> Listar();

        IList<ContaSaldoModel> ListarSaldo(ContaSaldoQueryModel query);

        ExtratoModel Extrato(ExtratoQueryModel query);

        DespesasPorCategoriaModel DespesasPorCategoria(DespesasPorCategoriaQueryModel query);
    }
}
