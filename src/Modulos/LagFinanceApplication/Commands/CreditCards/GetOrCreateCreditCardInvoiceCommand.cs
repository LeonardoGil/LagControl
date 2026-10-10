using LagFinanceDomain.Entities;
using MediatR;

namespace LagFinanceApplication.Commands.CreditCards
{
    public record GetOrCreateCreditCardInvoiceCommand : IRequest<CreditCardInvoice>
    {
        public required Guid CreditCardId { get; set; }

        public required DateOnly ReferenceDate { get; set; }
    }
}
