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

        public IList<CategoriaListaModel> Listar()
        {
            var categorias = _categoriaRepository.Get().AsNoTracking();

            return [.. categorias.Select(categoria => new CategoriaListaModel
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            })
            .OrderBy(x => x.Descricao)];
        }
    }
}
