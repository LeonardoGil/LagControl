namespace LagFinanceApplication.Models.Movimentacoes
{
    public class ListarMovimentacaoQueryModel
    {
        public IList<Guid>? ContaIds { get; set; }

        public bool ApenasPendentes { get; set; }
    }
}
