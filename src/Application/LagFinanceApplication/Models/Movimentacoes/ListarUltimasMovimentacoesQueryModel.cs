namespace LagFinanceApplication.Models.Movimentacoes
{
    public class ListarUltimasMovimentacoesQueryModel
    {
        public IList<Guid>? ContaIds { get; set; }

        public int Total { get; set; } = 10;
    }
}
