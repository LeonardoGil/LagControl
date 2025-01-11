using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class Conta : Entity
    {
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
