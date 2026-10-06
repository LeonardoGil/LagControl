using LagFinanceApplication.Commands.CreditCards;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.CreditCards
{
    public class AddCreditCardTransactionHandler(ICreditCardTransactionRepository transactionRepository) : IRequestHandler<AddCreditCardTransactionCommand>
    {
        public Task<Unit> Handle(AddCreditCardTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new CreditCardTransaction
            {
                Description = request.Description,
                Amount = request.Amount,
                Date = request.Date,
                Pending = request.Pending,
                Installments = request.Installments,
                InstallmentNumber = request.InstallmentNumber,
                CreditCardId = request.CreditCardId,
                InvoiceId = request.InvoiceId,
                CategoryId = request.CategoryId
            };

            transactionRepository.Add(transaction);
            transactionRepository.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
