using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Categorias;
using LagFinanceDomain.Domain;
using LagFinanceInfra.Interfaces;

namespace LagFinanceApplication.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Adicionar(AdicionarCategoriaModel categoriaModel)
        {
            var categoria = new Categoria
            {
                Descricao = categoriaModel.Descricao,
                Tipo = categoriaModel.Tipo
            };

            _categoriaRepository.Add(categoria);
            _categoriaRepository.SaveChanges();
        }
    }
}
