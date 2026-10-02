using LagFinanceApplication.Commands.Transactions;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class AddTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<AddTransactionCommand>
    {
        public Task<Unit> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                CategoryId = request.CategoryId,
                AccountId = request.AccountId,
                Amount = request.Amount,
                Description = request.Description,
                Notes = request.Notes,
                Date = request.Date,
                TransactionType = request.Type,
                Pending = request.Pending
            };

            transactionRepository.Add(transaction);
            transactionRepository.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}

