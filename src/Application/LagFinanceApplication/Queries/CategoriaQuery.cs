using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaQuery(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IList<CategoriaListarModel> Listar(CategoriaListarQueryModel query)
        {
            var categorias = _categoriaRepository.Get().AsNoTracking();

            if (query.Tipo.HasValue)
                categorias = categorias.Where(x => x.Tipo == query.Tipo.Value);

            return [.. categorias.Select(categoria => new CategoriaListarModel
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            })
            .OrderBy(x => x.Descricao)];
        }
    }
}
