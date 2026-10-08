using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class CreateCreditCardInvoiceHandler(ICreditCardInvoiceRepository invoiceRepository, 
                                                ICreditCardRepository creditCardRepository) : IRequestHandler<CreateCreditCardInvoiceCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCreditCardInvoiceCommand request, CancellationToken cancellationToken)
        {
            var creditCard = await creditCardRepository.GetByIdAsync(request.CreditCardId, cancellationToken, nameof(CreditCard.Invoices)) 
                ?? throw new Exception($"Credit card with ID {request.CreditCardId} not found.");
            
            if (creditCard.Invoices!.Any(i => i.ReferenceMonth == request.Month && i.ReferenceYear == request.Year))
                throw new Exception($"Invoice for credit card with ID {request.CreditCardId} and reference month {request.Month} and reference year {request.Year} already exists.");

            var closingDate = new DateTime(request.Year, request.Month, creditCard.ClosingDay);
            var dueDate = new DateTime(request.Year, request.Month, creditCard.DueDay);

            if (creditCard.DueDay < closingDate.Day)
                dueDate = new DateTime(request.Year, request.Month, creditCard.DueDay).AddMonths(1);

            var invoice = new CreditCardInvoice
            {
                CreditCardId = request.CreditCardId,
                ReferenceMonth = request.Month,
                ReferenceYear = request.Year,
                ClosingDate = closingDate,
                DueDate = dueDate
            };

            invoiceRepository.Add(invoice);

            await invoiceRepository.SaveChangesAsync(cancellationToken);

            return invoice.Id;
        }
    }
}
