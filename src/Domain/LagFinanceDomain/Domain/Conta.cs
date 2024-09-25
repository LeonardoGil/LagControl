using LagFinanceDomain.Enum;

namespace LagFinanceDomain.Domain
{
    public class Conta
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public virtual List<Movimentacao> Movimentacoes { get; set; }

        public decimal Saldo()
        {
            if (Movimentacoes is null)
                return decimal.Zero;

            var receitas = Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita).Sum(x => x.Valor);
            var despesas = Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa).Sum(x => x.Valor);

            return receitas - despesas;
        }
    }
}
