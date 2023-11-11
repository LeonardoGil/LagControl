 using LagFinanceLib.Domain.Enum;

namespace LagFinanceLib.Domain
{
    public class Lancamento
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateOnly Data { get; set; }

        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        #region Relacionamentos

        public Guid ContaId { get; set; }

        public Guid? CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        #endregion
    }
}
