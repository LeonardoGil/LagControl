using LagFinanceApplication.Models.Categorias;

namespace LagFinanceApplication.Interfaces
{
    public interface ICategoriaQuery
    {
        IList<CategoriaListarModel> Listar(CategoriaListarQueryModel query);
    }
}
