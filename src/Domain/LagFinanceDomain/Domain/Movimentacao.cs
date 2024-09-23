using LagFinanceDomain.Enum;

namespace LagFinanceDomain.Domain
{
    public class Movimentacao
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        public bool Pendente { get; set; }

        #region Relacionamentos

        public Guid ContaId { get; set; }

        public virtual Conta Conta { get; set; }

        public Guid? ContaTransferenciaId { get; set; }

        public virtual Conta ContaTransferencia { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        #endregion
    }
}
