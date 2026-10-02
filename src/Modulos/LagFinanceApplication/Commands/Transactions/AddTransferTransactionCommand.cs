using MediatR;

namespace LagFinanceApplication.Commands.Transactions
{
    public record AddTransferTransactionCommand : IRequest<Unit>
    {
        public required string Description { get; set; }

        public string? Notes { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid AccountId { get; set; }

        public Guid TransferAccountId { get; set; }

        public bool Pending { get; set; }
    }
}
