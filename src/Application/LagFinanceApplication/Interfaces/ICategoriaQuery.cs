using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface ICategoriaQuery
    {
        IList<CategoriaListaModel> Listar();
    }
}
