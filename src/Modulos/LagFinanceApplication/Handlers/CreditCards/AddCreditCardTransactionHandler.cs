using LagControlUtil.Extensions;
using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class AddCreditCardTransactionHandler(ICreditCardTransactionRepository repository, ICreditCardRepository creditCardRepository, IMediator mediator) : IRequestHandler<AddCreditCardTransactionCommand>
    {
        public async Task<Unit> Handle(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateCreditLimitAsync(request, cancellationToken);

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

        private async Task ValidateCreditLimitAsync(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            var creditCard = await creditCardRepository.GetByIdAsync(request.CreditCardId, cancellationToken, nameof(CreditCard.Invoices), "Invoices.Transactions")
                ?? throw new Exception($"Credit card with ID {request.CreditCardId} not found.");

            var available = creditCard.AvailableCredit();

            if (request.Amount > available)
                throw new Exception("Credit card limit exceeded");
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
            var amounts = request.Amount.SplitAmount(request.Installments!.Value);

            for (int i = 1; i <= request.Installments; i++)
            {
                var referenceDate = request.Date.AddMonths(i - 1);

                var transaction = new CreditCardTransaction
                {
                    Description = request.Description,
                    Amount = amounts[i - 1],
                    Date = referenceDate,
                    Pending = request.Pending,
                    CreditCardId = request.CreditCardId,
                    CategoryId = request.CategoryId,
                    Installments = request.Installments,
                    InstallmentNumber = i
                };

                await LinkTransactionToInvoiceAsync(transaction, cancellationToken);

                repository.Add(transaction);
            }

            await repository.SaveChangesAsync(cancellationToken);
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
