using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class Movimentacao : Entity
    {
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

        public virtual Conta? ContaTransferencia { get; set; }

        public Guid CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        #endregion

        public decimal ValorSaldo()
        {
            switch (TipoMovimentacao)
            {
                case TipoMovimentacaoEnum.Receita:
                    return Valor;
                
                case TipoMovimentacaoEnum.Despesa:
                case TipoMovimentacaoEnum.Transferencia:
                    return -Math.Abs(Valor);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
