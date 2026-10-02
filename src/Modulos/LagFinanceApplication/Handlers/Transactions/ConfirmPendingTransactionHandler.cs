using LagFinanceApplication.Commands.Transactions;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class ConfirmPendingTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<ConfirmPendingTransactionCommand>
    {
        public Task<Unit> Handle(ConfirmPendingTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = transactionRepository.Get().FirstOrDefault(x => x.Id == request.Id) ?? throw new Exception("Transaction not found");

            transaction.Description = request.Description ?? transaction.Description;
            transaction.Notes = request.Notes ?? transaction.Notes;
            transaction.Amount = request.Amount ?? transaction.Amount;
            transaction.Date = request.Date ?? transaction.Date;
            transaction.AccountId = request.AccountId ?? transaction.AccountId;
            transaction.CategoryId = request.CategoryId ?? transaction.CategoryId;
            transaction.Pending = false;

            transactionRepository.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}

