namespace LagFinanceApplication.Dtos.Accounts
{
    public record AccountBalanceDto
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public decimal Balance { get; set; }

        public decimal ExpectedBalance { get; set; }

        public DateTime? LastTransactionDate { get; set; }
    }
}

