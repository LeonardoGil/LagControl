using LagFinanceApplication.Commands.Transactions;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;
using LagFinanceInfra.Interfaces;
using MediatR;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class AddTransferTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<AddTransferTransactionCommand>
    {
        public Task<Unit> Handle(AddTransferTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                Description = request.Description,
                Notes = request.Notes,
                Date = request.Date,
                TransactionType = TransactionTypeEnum.Transfer,
                TransferAccountId = request.TransferAccountId,
                Pending = request.Pending
            };

            transactionRepository.Add(transaction);
            transactionRepository.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
