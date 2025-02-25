using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Models.Movimentacoes
{
    public class ListarMovimentacaoQueryModel
    {
        public string? Descricao { get; set; }

        public IList<Guid>? ContaIds { get; set; }

        public IList<Guid>? CategoriaIds { get; set; }

        public bool ApenasPendentes { get; set; }

        public DateTime? DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }

        public TipoMovimentacaoEnum? Tipo { get; set; }

    }
}
