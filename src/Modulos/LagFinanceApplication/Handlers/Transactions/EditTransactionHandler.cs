using LagFinanceApplication.Commands.Transactions;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class EditTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<EditTransactionCommand>
    {
        public async Task<Unit> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await transactionRepository.Get().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("Transaction not found");

            UpdateFields(transaction, request);

            transactionRepository.SaveChanges();

            return Unit.Value;
        }

        private static void UpdateFields(Transaction transaction, EditTransactionCommand request)
        {
            transaction.Description = request.Description ?? transaction.Description;
            transaction.Notes = request.Notes ?? transaction.Notes;
            transaction.Amount = request.Amount ?? transaction.Amount;
            transaction.Date = request.Date ?? transaction.Date;
            transaction.Pending = request.Pending ?? transaction.Pending;
            transaction.AccountId = request.AccountId ?? transaction.AccountId;
            transaction.CategoryId = request.CategoryId ?? transaction.CategoryId;
        }
    }
}

