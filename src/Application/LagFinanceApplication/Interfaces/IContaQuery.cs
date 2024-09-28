using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface IContaQuery
    {
        IList<ContaListaModel> Listar();

        IList<ContaSaldoModel> ListarSaldo(ListarSaldoQueryModel query);

        ExtratoModel Extrato(ExtratoQueryModel query);
    }
}
