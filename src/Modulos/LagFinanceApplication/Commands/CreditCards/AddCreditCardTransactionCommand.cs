using MediatR;

namespace LagFinanceApplication.Commands.CreditCards
{
    public record AddCreditCardTransactionCommand : IRequest<Unit>
    {
        public required string Description { get; set; }

        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public bool Pending { get; set; }

        public int? Installments { get; set; }

        public required Guid CreditCardId { get; set; }

        public required Guid CategoryId { get; set; }
    }
}
