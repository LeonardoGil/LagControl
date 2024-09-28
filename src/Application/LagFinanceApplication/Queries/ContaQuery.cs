using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using LagFinanceDomain.Enum;
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

        public IList<ContaSaldoModel> ListarSaldo(ListarSaldoQueryModel model)
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

        public ExtratoModel Extrato(ExtratoQueryModel query)
        {
            var conta = _contaRepository.Get()
                                        .Include(x => x.Movimentacoes).ThenInclude(x => x.Categoria)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == query.ContaId) ?? throw new NotImplementedException($"Conta '{query.ContaId}' não encontrada");

            if (!conta.Movimentacoes.Any())
                throw new Exception("Conta não possui Movimentações");

            var movimentacoesDia = conta.Movimentacoes.GroupBy(x => x.Data.Date)
                                                      .Select(x => new ExtratoGroupModel
                                                      {
                                                          Dia = DateOnly.FromDateTime(x.Key),
                                                          Movimentacoes = x.Select(mov => new MovimentacaoModel
                                                          {
                                                              Conta = mov.Conta.Descricao,
                                                              Categoria = mov.Categoria.Descricao,
                                                              ContaTransferencia = mov.ContaTransferencia?.Descricao,
                                                              Data = mov.Data,
                                                              Descricao = mov.Descricao,
                                                              Observacao = mov.Observacao,
                                                              Pendente = mov.Pendente,
                                                              TipoMovimentacao = mov.TipoMovimentacao,
                                                              Valor = mov.Valor
                                                          }).ToList(),
                                                      })
                                                      .OrderBy(x => x.Dia)
                                                      .ToArray();

            var valorInicial = decimal.Zero;

            foreach (var movimentacaoDia in movimentacoesDia)
            {
                var despesas = movimentacaoDia.Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa).Sum(x => x.Valor);
                var receitas = movimentacaoDia.Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita).Sum(x => x.Valor);

                var valorTotal = receitas - despesas;
                var valorFinal = valorInicial + valorTotal;

                movimentacaoDia.ValorTotal = valorTotal;
                movimentacaoDia.ValorInicialDia = valorInicial;
                movimentacaoDia.ValorFinalDia = valorFinal;

                valorInicial = valorFinal;
            }

            return new ExtratoModel
            {
                Conta = conta.Descricao,
                DataInicio = movimentacoesDia.First().Dia,
                DataFim = movimentacoesDia.Last().Dia,

                ValorInicial = movimentacoesDia.First().ValorInicialDia,
                ValorFinal = movimentacoesDia.Last().ValorFinalDia,

                ExtratosDia = movimentacoesDia
            };
        }
    }
}
