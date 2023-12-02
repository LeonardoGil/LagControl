 using LagFinanceLib.Domain.Enum;

namespace LagFinanceLib.Domain
{
    public class Movimentacao
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        #region Relacionamentos

        public Guid ContaId { get; set; }

        public virtual Conta Conta { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        #endregion
    }
}
