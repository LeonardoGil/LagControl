namespace LagFinanceDomain.Domain
{
    public class Conta
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public virtual List<Movimentacao> Movimentacoes { get; set; }
    }
}
