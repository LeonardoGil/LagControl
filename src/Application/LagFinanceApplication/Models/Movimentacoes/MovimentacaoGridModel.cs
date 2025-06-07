using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Models.Movimentacoes
{
    public class MovimentacaoGridModel
    {
        public Guid Id { get; set; }

        public string? Descricao { get; set; }

        public string? Observacao { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorSaldo { get; set; }

        public DateTime Data { get; set; }

        public TipoMovimentacaoEnum Tipo { get; set; }

        public bool Pendente { get; set; }

        public string? Conta { get; set; }
        
        public string? ContaId { get; set; }

        public string? ContaTransferencia { get; set; }

        public string? Categoria { get; set; }

        public string? CategoriaId { get; set; }
    }
}
