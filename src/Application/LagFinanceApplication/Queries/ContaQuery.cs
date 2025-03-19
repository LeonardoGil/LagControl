using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Contas;
using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class ContaQuery : IContaQuery
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ContaQuery(IContaRepository contaRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _contaRepository = contaRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public IList<ContaSaldoModel> ListarSaldo(ContaSaldoQueryModel model)
        {
            var contas = _contaRepository.Get().Where(x => model.ContaIds == null || model.ContaIds.Contains(x.Id)).AsNoTracking();

            var models = contas.Include(x => x.Movimentacoes).Select(conta => new ContaSaldoModel
            {
                Id = conta.Id,
                Descricao = conta.Descricao,
                Saldo = conta.Movimentacoes.Where(x => !x.Pendente).Sum(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita ? x.Valor : x.Valor * -1),
                SaldoPrevisto = conta.Movimentacoes.Sum(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita ? x.Valor : x.Valor * -1),
                DataUltimaMovimentacao = conta.Movimentacoes.Where(x => !x.Pendente).OrderByDescending(x => x.Data).Select(x => (DateTime?)x.Data).FirstOrDefault() 
            });

            return [.. models];
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

        public ExtratoModel Extrato(ExtratoQueryModel query)
        {
            var conta = _contaRepository.Get()
                                        .Include(x => x.Movimentacoes).ThenInclude(x => x.Categoria)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == query.ContaId) ?? throw new NotImplementedException($"Conta '{query.ContaId}' não encontrada");

            if (!conta.Movimentacoes.Any())
                throw new Exception("Conta não possui Movimentações");

            var valorSaldoAnterior = conta.Movimentacoes.Where(x => DateOnly.FromDateTime(x.Data) < query.DataInicio)
                                                        .Where(x => !x.Pendente)
                                                        .Sum(x => x.ValorSaldo());

            Func<Movimentacao, bool> filtroPorPeriodo = x => DateOnly.FromDateTime(x.Data) >= query.DataInicio && DateOnly.FromDateTime(x.Data) <= query.DataFim;
            Func<Movimentacao, bool> filtroPendentesAntesDoPeriodo = x => DateOnly.FromDateTime(x.Data) < query.DataInicio && x.Pendente;

            var movimentacoes = conta.Movimentacoes.Where(x => filtroPorPeriodo.Invoke(x) ||
                                                               filtroPendentesAntesDoPeriodo.Invoke(x))
                                                   .ToList();

            return new ExtratoModel(conta.Descricao, movimentacoes, query.DataInicio, query.DataFim, valorSaldoAnterior);
        }

        public DespesasPorCategoriaModel DespesasPorCategoria(DespesasPorCategoriaQueryModel query)
        {
            var conta = _contaRepository.Get()
                                        .Include(x => x.Movimentacoes.Where(x => DateOnly.FromDateTime(x.Data) >= query.DataInicio && DateOnly.FromDateTime(x.Data) <= query.DataFim))
                                        .ThenInclude(x => x.Categoria)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == query.ContaId) ?? throw new NotImplementedException($"Conta '{query.ContaId}' não encontrada");

            var despesasPorCategoria = new DespesasPorCategoriaModel(conta);

            return despesasPorCategoria;
        }
    }
}
