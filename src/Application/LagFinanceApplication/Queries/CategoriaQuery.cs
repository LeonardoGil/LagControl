using LagControlUtil.Extensions;
using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Categorias;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class CategoriaQuery(ICategoriaRepository _categoriaRepository) : ICategoriaQuery
    {
        public IList<CategoriaListarModel> Listar(CategoriaListarQueryModel query)
        {
            var categorias = _categoriaRepository.Get().Where(x => query.Tipo.HasValue && x.Tipo == query.Tipo.Value)
                                                       .Include(x => x.CategoriaPai)
                                                       .Select(categoria => new CategoriaListarModel
                                                       {
                                                           Id = categoria.Id,
                                                           Descricao = categoria.Descricao,

                                                           CategoriaPai = !categoria.CategoriaPai.ENull() ? new CategoriaListarModel
                                                           {
                                                               Descricao = categoria.CategoriaPai.Descricao,
                                                               Id = categoria.CategoriaPai.Id,
                                                           } 
                                                           : default
                                                       })
                                                       .OrderBy(x => x.Descricao);

            return [.. categorias];
        }
    }
}
