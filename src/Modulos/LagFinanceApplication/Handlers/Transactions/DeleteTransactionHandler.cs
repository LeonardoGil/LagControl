using LagFinanceApplication.Commands.Transactions;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class DeleteTransactionHandler(ITransactionRepository transactionRepository) : IRequestHandler<DeleteTransactionCommand>
    {
        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await transactionRepository.Get().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("Transaction not found");

            transactionRepository.Remove(transaction);
            transactionRepository.SaveChanges();

            return Unit.Value;
        }
    }
}

