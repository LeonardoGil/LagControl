using LagFinanceApplication.Models;

namespace LagFinanceApplication.Interfaces
{
    public interface ICategoriaQuery
    {
        IList<CategoriaListarModel> Listar(CategoriaListarQueryModel query);
    }
}
