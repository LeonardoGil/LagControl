using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface IContaQuery
    {
        IList<ContaListaModel> Listar();

        IList<ContaSaldoModel> ConsultarSaldo(ConsultarSaldoQueryModel query);
    }
}
