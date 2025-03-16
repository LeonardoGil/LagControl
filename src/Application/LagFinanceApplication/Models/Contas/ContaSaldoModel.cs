namespace LagFinanceApplication.Models.Contas
{
    public record ContaSaldoModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public decimal Saldo { get; set; }

        public decimal SaldoPrevisto { get; set; }

        public DateTime? DataUltimaMovimentacao { get; set; }
    }
}
