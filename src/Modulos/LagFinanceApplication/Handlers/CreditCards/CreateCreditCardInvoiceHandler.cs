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

            var referenceDate = request.ReferenceDate;

            if (creditCard.Invoices!.Any(i => referenceDate >= i.OpeningDate && referenceDate < i.ClosingDate))
                throw new InvalidOperationException($"An invoice for credit card {request.CreditCardId} already exists for reference date {referenceDate:d}.");

            var closingDate = ProcessClosingDate(creditCard, referenceDate);
            var dueDate = ProcessDueDate(creditCard, closingDate);
            var openingDate = ProcessOpeningDate(creditCard, closingDate);

            var invoice = new CreditCardInvoice
            {
                CreditCardId = request.CreditCardId,
                ReferenceMonth = closingDate.Month,
                ReferenceYear = closingDate.Year,
                ClosingDate = closingDate,
                OpeningDate = openingDate,
                DueDate = dueDate
            };

            await invoiceRepository.TransactionAsync(async () =>
            {
                invoiceRepository.Add(invoice);

                await invoiceRepository.SaveChangesAsync(cancellationToken);

            }, cancellationToken);

            return invoice.Id;
        }

        private static DateOnly ProcessClosingDate(CreditCard creditCard, DateOnly referenceDate)
        {
            var date = referenceDate;

            if (referenceDate.Day >= creditCard.ClosingDay)
                date = date.AddMonths(1);

            return new DateOnly(date.Year, date.Month, creditCard.ClosingDay);
        }

        private static DateOnly ProcessOpeningDate(CreditCard creditCard, DateOnly closingDate)
        {
            var date = closingDate.AddMonths(-1);

            return new DateOnly(date.Year,date.Month, creditCard.ClosingDay).AddDays(1);
        }

        private static DateOnly ProcessDueDate(CreditCard creditCard, DateOnly closingDate)
        {
            var dueDate = new DateOnly(closingDate.Year, closingDate.Month, creditCard.DueDay);

            if (dueDate <= closingDate)
                dueDate = dueDate.AddMonths(1);

            return dueDate;
        }
    }
}
