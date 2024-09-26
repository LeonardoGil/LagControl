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

        public IList<ContaSaldoModel> ConsultarSaldo(ConsultarSaldoQueryModel model)
        {
            var contas = _contaRepository.Get().AsNoTracking();

            if (model.ContaIds is not null && model.ContaIds.Any())
                contas = contas.Where(x => model.ContaIds.Contains(x.Id));

            return [.. contas.Include(x => x.Movimentacoes)
                             .Select(conta => new ContaSaldoModel
                             {
                                 Descricao = conta.Descricao,
                                 Saldo = conta.Saldo()
                             })];
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
