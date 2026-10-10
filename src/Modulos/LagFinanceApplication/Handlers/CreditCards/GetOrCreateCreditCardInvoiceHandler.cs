using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class GetOrCreateCreditCardInvoiceHandler(ICreditCardInvoiceRepository invoiceRepository,
                                                ICreditCardRepository creditCardRepository) : IRequestHandler<GetOrCreateCreditCardInvoiceCommand, CreditCardInvoice>
    {
        public async Task<CreditCardInvoice> Handle(GetOrCreateCreditCardInvoiceCommand request, CancellationToken cancellationToken)
        {
            var creditCard = await creditCardRepository.GetByIdAsync(request.CreditCardId, cancellationToken, nameof(CreditCard.Invoices))
                ?? throw new Exception($"Credit card with ID {request.CreditCardId} not found.");

            var referenceDate = request.ReferenceDate;

            var invoice = creditCard.Invoices!.FirstOrDefault(i => referenceDate >= i.OpeningDate && referenceDate < i.ClosingDate);

            if (invoice is not null)
                return invoice;

            var closingDate = ProcessClosingDate(creditCard, referenceDate);
            var dueDate = ProcessDueDate(creditCard, closingDate);
            var openingDate = ProcessOpeningDate(creditCard, closingDate);

            invoice = new CreditCardInvoice
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

            return invoice;
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
