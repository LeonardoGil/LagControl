using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Models.Movimentacoes
{
    public class AdicionarMovimentacaoModel
    {
        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public Guid ContaId { get; set; }

        public Guid CategoriaId { get; set; }

        public TipoMovimentacaoEnum Tipo { get; set; }

        public bool Pendente { get; set; }
    }
}
