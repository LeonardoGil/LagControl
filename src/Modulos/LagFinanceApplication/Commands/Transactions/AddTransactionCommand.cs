using LagFinanceDomain.Enums;
using MediatR;

namespace LagFinanceApplication.Commands.Transactions
{
    public record AddTransactionCommand : IRequest<Unit>
    {
        public required string Description { get; set; }

        public string? Notes { get; set; } 

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid AccountId { get; set; }

        public Guid CategoryId { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public bool Pending { get; set; }
    }
}

