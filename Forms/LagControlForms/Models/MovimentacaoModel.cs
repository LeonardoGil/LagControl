using LagFinanceLib.Domain.Enum;

namespace LagControlForms.Models
{
    public class MovimentacaoModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        public string Conta { get; set; }

        public string Categoria { get; set; }
    }
}
