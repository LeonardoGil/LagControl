using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Domain;
using LagFinanceDomain.Enum;

namespace LagFinanceApplication.Models.Contas
{
    public class ExtratoModel
    {
        public string Conta { get; set; }

        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }

        public ExtratoPendenteModel ExtratoPendente { get; set; }

        public IList<ExtratoGroupModel> ExtratosDia { get; set; }

        public ExtratoModel(Conta conta)
        {
            Conta = conta.Descricao;
            ExtratosDia = DefinirExtratoGroup(conta.Movimentacoes);

            if (ExtratosDia.Any())
            {
                DataInicio = ExtratosDia.First().Dia;
                DataFim = ExtratosDia.Last().Dia;

                ValorInicial = ExtratosDia.First().ValorInicialDia;
                ValorFinal = ExtratosDia.Last().ValorFinalDia;
            }

            ExtratoPendente = DefinirExtratoPendente(conta.Movimentacoes);
        }

        private ExtratoPendenteModel DefinirExtratoPendente(IList<Movimentacao> movimentacoes)
        {
            var movimentacoesPendentes = movimentacoes.Where(x => x.Pendente);

            if (!movimentacoesPendentes.Any())
                return null;

            var valorTotal = movimentacoesPendentes.Sum(x => x.Valor);

            return new ExtratoPendenteModel
            {
                Movimentacoes = movimentacoesPendentes.Select(mov => new MovimentacaoModel
                {
                    Id = mov.Id,
                    Conta = mov.Conta.Descricao,
                    Categoria = mov.Categoria.Descricao,
                    ContaTransferencia = mov.ContaTransferencia?.Descricao,
                    Data = mov.Data,
                    Descricao = mov.Descricao,
                    Observacao = mov.Observacao,
                    Pendente = mov.Pendente,
                    TipoMovimentacao = mov.TipoMovimentacao,
                    Valor = mov.Valor
                })
                .ToList(),

                ValorTotal = valorTotal,
                ValorFinal = ValorFinal - valorTotal
            };
        }

        public IList<ExtratoGroupModel> DefinirExtratoGroup(IList<Movimentacao> movimentacoes)
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

            return movimentacoesDia;
        }
    }

    public class ExtratoGroupModel
    {
        public DateOnly Dia { get; set; }

        public IList<MovimentacaoModel> Movimentacoes { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorInicialDia { get; set; }
        public decimal ValorFinalDia { get; set; }
    }

    public class ExtratoPendenteModel
    {
        public IList<MovimentacaoModel> Movimentacoes { get; set; }

        public decimal ValorTotal { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
