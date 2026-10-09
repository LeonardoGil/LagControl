using Azure.Core;
using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using LagFinanceInfra.Repositories;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class AddCreditCardTransactionHandler(ICreditCardTransactionRepository repository, ICreditCardInvoiceRepository invoiceRepository) : IRequestHandler<AddCreditCardTransactionCommand>
    {
        public async Task<Unit> Handle(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            await repository.TransactionAsync(async () => await ProcessAsync(request), cancellationToken);

            return Unit.Value;
        }

        private async Task ProcessAsync(AddCreditCardTransactionCommand request)
        {
            if (request.Installments.HasValue)
            {
                await AddInstallmentTransactionAsync(request);
            }
            else
            {
                await AddTransactionAsync(request);
            }
        }

        private async Task AddTransactionAsync(AddCreditCardTransactionCommand request)
        {
            var transaction = new CreditCardTransaction
            {
                Description = request.Description,
                Amount = request.Amount,
                Date = request.Date,
                Pending = request.Pending,
                CreditCardId = request.CreditCardId,
                CategoryId = request.CategoryId
            };



            repository.Add(transaction);

            await repository.SaveChangesAsync();
        }

        private async Task AddInstallmentTransactionAsync(AddCreditCardTransactionCommand request)
        {

        }

        private async Task LinkTransactionToInvoiceAsync(CreditCardTransaction transaction)
        {
            var invoiceId = await invoiceRepository.FindInvoiceIdByReferenceDateAsync(transaction.Date.Month, transaction.Date.Year, transaction.CreditCardId);
            
            if (invoiceId != Guid.Empty)
            {
                transaction.CreditCardInvoiceId = invoiceId;
            }
        }
    }
}
