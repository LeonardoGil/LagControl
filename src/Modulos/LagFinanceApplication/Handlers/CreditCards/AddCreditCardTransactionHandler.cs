using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class AddCreditCardTransactionHandler(ICreditCardTransactionRepository repository, IMediator mediator) : IRequestHandler<AddCreditCardTransactionCommand>
    {
        public async Task<Unit> Handle(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            await repository.TransactionAsync(async () => await ProcessAsync(request, cancellationToken), cancellationToken);

            return Unit.Value;
        }

        private async Task ProcessAsync(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            if (request.Installments.HasValue)
            {
                await AddInstallmentTransactionAsync(request, cancellationToken);
            }
            else
            {
                await AddTransactionAsync(request, cancellationToken);
            }
        }

        private async Task AddTransactionAsync(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
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

            await LinkTransactionToInvoiceAsync(transaction, cancellationToken);

            repository.Add(transaction);

            await repository.SaveChangesAsync(cancellationToken);
        }

        private async Task AddInstallmentTransactionAsync(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Installment transactions are not implemented yet.");
        }

        private async Task LinkTransactionToInvoiceAsync(CreditCardTransaction transaction, CancellationToken cancellationToken)
        {
            var createInvoice = new GetOrCreateCreditCardInvoiceCommand
            {
                CreditCardId = transaction.CreditCardId,
                ReferenceDate = transaction.Date
            };
            
            var invoice = await mediator.Send(createInvoice, cancellationToken);

            transaction.InvoiceId = invoice.Id;
        }
    }
}
