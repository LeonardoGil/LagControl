using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Models.Contas
{
    public class ExtratoModel
    {
        public string Conta { get; set; }

        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public decimal SaldoInicial { get; set; }
        public decimal SaldoFinal { get; set; }

        public ExtratoPendenteModel? ExtratoPendente { get; set; }

        public IList<ExtratoGroupModel> ExtratosDia { get; set; }

        public ExtratoModel(string conta, IList<Movimentacao> movimentacoes, DateOnly dataInicio, DateOnly dataFim, decimal valorSaldoAnterior = decimal.Zero)
        {
            Conta = conta;
            ExtratosDia = DefinirExtratoGroup(movimentacoes, valorSaldoAnterior);

            DataInicio = dataInicio;
            DataFim = dataFim;

            SaldoInicial = valorSaldoAnterior;
            SaldoFinal = ExtratosDia.LastOrDefault()?.ValorFinalDia ?? valorSaldoAnterior;

            ExtratoPendente = DefinirExtratoPendente(movimentacoes);
        }

        private ExtratoPendenteModel? DefinirExtratoPendente(IList<Movimentacao> movimentacoes)
        {
            var movimentacoesPendentes = movimentacoes.Where(x => x.Pendente);

            if (!movimentacoesPendentes.Any())
                return null;

            var receitas = movimentacoesPendentes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita).Sum(x => x.Valor);
            var despesas = movimentacoesPendentes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa).Sum(x => x.Valor);
            var valorTotal = receitas - despesas;

            return new ExtratoPendenteModel
            {
                Movimentacoes = movimentacoesPendentes.Select(mov => new MovimentacaoModel
                {
                    Id = mov.Id,
                    Conta = mov.Conta.Descricao,
                    Categoria = mov.Categoria.Descricao,
                    ContaTransferencia = mov.ContaTransferencia?.Descricao ?? string.Empty,
                    Data = mov.Data,
                    Descricao = mov.Descricao,
                    Observacao = mov.Observacao,
                    Pendente = mov.Pendente,
                    TipoMovimentacao = mov.TipoMovimentacao,
                    Valor = mov.Valor
                })
                .ToList(),

                ValorTotalDespesa = despesas,
                ValorTotalReceita = receitas,

                SaldoPrevisto = SaldoFinal + valorTotal
            };
        }

        public IList<ExtratoGroupModel> DefinirExtratoGroup(IList<Movimentacao> movimentacoes, decimal saldoAnterior = 0)
        {
            var movimentacoesDia = movimentacoes.Where(x => !x.Pendente)
                                                .GroupBy(x => x.Data.Date)
                                                .Select(x => new ExtratoGroupModel
                                                {
                                                    Dia = DateOnly.FromDateTime(x.Key),
                                                    Movimentacoes = x.Select(mov => new MovimentacaoModel
                                                    {
                                                        Id = mov.Id,
                                                        Conta = mov.Conta.Descricao,
                                                        Categoria = mov.Categoria.Descricao,
                                                        ContaTransferencia = mov.ContaTransferencia?.Descricao ?? string.Empty,
                                                        Data = mov.Data,
                                                        Descricao = mov.Descricao,
                                                        Observacao = mov.Observacao,
                                                        Pendente = mov.Pendente,
                                                        TipoMovimentacao = mov.TipoMovimentacao,
                                                        Valor = mov.Valor,
                                                        ValorSaldo = mov.ValorSaldo()
                                                    }).ToList(),
                                                })
                                                .OrderBy(x => x.Dia)
                                                .ToArray();

            var valorInicial = saldoAnterior;

            foreach (var movimentacaoDia in movimentacoesDia)
            {
                var valorTotal = movimentacaoDia.Movimentacoes.Sum(x => x.ValorSaldo);
                var valorFinal = valorInicial + valorTotal;
                movimentacaoDia.ValorTotal = valorTotal;
                movimentacaoDia.ValorInicialDia = valorInicial;
                movimentacaoDia.ValorFinalDia = valorFinal;

                valorInicial = valorFinal;
            }

            return movimentacoesDia;
        }
    }

    public class ExtratoGroupModel
    {
        public DateOnly Dia { get; set; }

        public required IList<MovimentacaoModel> Movimentacoes { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorInicialDia { get; set; }
        public decimal ValorFinalDia { get; set; }
    }

    public class ExtratoPendenteModel
    {
        public required IList<MovimentacaoModel> Movimentacoes { get; set; }

        public decimal ValorTotalDespesa { get; set; }
        public decimal ValorTotalReceita { get; set; }

        public decimal SaldoPrevisto { get; set; }
    }
}
