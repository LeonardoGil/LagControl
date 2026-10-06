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
            
            var closingDate = new DateTime(request.Year, request.Month, creditCard.ClosingDay);

            if (creditCard.Invoices!.Any(i => i.ClosingDate == closingDate))
                throw new Exception($"Invoice for credit card with ID {request.CreditCardId} and closing date {closingDate} already exists.");

            var dueDate = new DateTime(request.Year, request.Month, creditCard.DueDay);

            if (creditCard.DueDay < closingDate.Day)
                dueDate = new DateTime(request.Year, request.Month, creditCard.DueDay).AddMonths(1);

            var invoice = new CreditCardInvoice
            {
                CreditCardId = request.CreditCardId,
                ClosingDate = closingDate,
                DueDate = dueDate
            };

            invoiceRepository.Add(invoice);

            await invoiceRepository.SaveChangesAsync(cancellationToken);

            return invoice.Id;
        }
    }
}
