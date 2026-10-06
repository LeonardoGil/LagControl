using MediatR;

namespace LagFinanceApplication.Commands.CreditCards
{
    public record CreateCreditCardInvoiceCommand : IRequest<Guid>
    {
        public required Guid CreditCardId { get; set; }

        public required int Month { get; set; }
        public required int Year { get; set; }
    }
}
