using LagBaseDomain;
using LagFinanceDomain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace LagFinanceDomain.Entities
{
    public class Conta : Entity
    {
        public required string Descricao { get; set; }

        public virtual List<Movimentacao>? Movimentacoes { get; set; }

        public decimal Saldo()
        {
            if (Movimentacoes is null)
                return decimal.Zero;

            var receitas = Movimentacoes.Where(x => !x.Pendente && x.TipoMovimentacao == TipoMovimentacaoEnum.Receita).Sum(x => x.Valor);
            var despesas = Movimentacoes.Where(x => !x.Pendente && x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa).Sum(x => x.Valor);

            return receitas - despesas;
        }

        public decimal SaldoPrevisto()
        {
            if (Movimentacoes is null)
                return decimal.Zero;

            var receitas = Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Receita).Sum(x => x.Valor);
            var despesas = Movimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacaoEnum.Despesa).Sum(x => x.Valor);

            return receitas - despesas;
        }

        public DateTime? DataUltimaMovimentacao()
        {
            return Movimentacoes?.OrderByDescending(x => x.Data).Select(x => x.Data).LastOrDefault() ?? default;
        }
    }
}
