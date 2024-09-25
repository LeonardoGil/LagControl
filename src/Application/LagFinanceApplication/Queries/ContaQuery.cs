using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class ContaQuery : IContaQuery
    {
        private readonly IContaRepository _contaRepository;

        public ContaQuery(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public IList<ContaListaModel> Listar()
        {
            var conta = _contaRepository.Get().AsNoTracking();

            return [.. conta.Select(conta => new ContaListaModel
            {
                Id = conta.Id,
                Descricao = conta.Descricao
            })];
        }
    }
}
