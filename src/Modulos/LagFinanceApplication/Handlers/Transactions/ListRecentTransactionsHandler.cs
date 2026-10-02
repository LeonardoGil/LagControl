using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Transactions;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class ListRecentTransactionsHandler(ITransactionRepository transactionRepository) : IRequestHandler<ListRecentTransactionsQuery, IList<TransactionGridDto>>
    {
        public async Task<IList<TransactionGridDto>> Handle(ListRecentTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactionsQuery = transactionRepository.Get().AsNoTracking();

            if (query.AccountIds is not null)
            {
                transactionsQuery = transactionsQuery.Where(x => query.AccountIds.Contains(x.Id));
            }

            var result = await transactionsQuery.Include(x => x.Account)
                                                .Include(x => x.TransferAccount)
                                                .Include(x => x.Category)
                                                .OrderByDescending(x => x.CreatedAt)
                                                .Take(query.Total)
                                                .Select(transaction => new TransactionGridDto
                                                {
                                                    Id = transaction.Id,
                                                    Date = transaction.Date,
                                                    Description = transaction.Description,
                                                    Notes = transaction.Notes,
                                                    Pending = transaction.Pending,
                                                    Type = transaction.TransactionType,
                                                    Amount = transaction.Amount,
                                                    Account = transaction.Account!.Description,
                                                    AccountId = transaction.AccountId,
                                                    Category = transaction.Category!.Description,
                                                    CategoryId = transaction.CategoryId,
                                                    TransferAccount = transaction.TransferAccount != null ? transaction.TransferAccount.Description : string.Empty
                                                })
                                                .ToListAsync(cancellationToken);

            return result;
        }
    }
}

