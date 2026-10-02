using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Dtos.Transactions
{
    public class TransactionGridDto
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        public decimal Amount { get; set; }

        public decimal BalanceAmount { get; set; }

        public DateTime Date { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public bool Pending { get; set; }

        public string? Account { get; set; }
        
        public Guid? AccountId { get; set; }

        public string? TransferAccount { get; set; }

        public Guid? TransferAccountId { get; set; }

        public string? Category { get; set; }

        public Guid? CategoryId { get; set; }
    }
}

