using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Transactions;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Transactions
{
    public class ListTransactionsHandler(ITransactionRepository transactionRepository) : IRequestHandler<ListTransactionsQuery, IList<TransactionGridDto>>
    {
        public async Task<IList<TransactionGridDto>> Handle(ListTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactionsQuery = transactionRepository.Get().AsNoTracking();

            if (!string.IsNullOrEmpty(query.Description))
                transactionsQuery = transactionsQuery.Where(x => x.Description.ToUpper().Contains(query.Description.ToUpper()));

            if (query.AccountIds is not null && query.AccountIds.Any())
                transactionsQuery = transactionsQuery.Where(x => query.AccountIds.Contains(x.AccountId));

            if (query.CategoryIds is not null && query.CategoryIds.Any())
                transactionsQuery = transactionsQuery.Where(x => x.CategoryId.HasValue && query.CategoryIds.Contains(x.CategoryId.Value));

            if (query.Type.HasValue)
                transactionsQuery = transactionsQuery.Where(x => x.TransactionType == query.Type.Value);

            if (query.PendingOnly)
                transactionsQuery = transactionsQuery.Where(x => x.Pending);

            if (query.StartDate.HasValue && query.EndDate.HasValue)
                transactionsQuery = transactionsQuery.Where(x => x.Date >= query.StartDate.Value && x.Date <= query.EndDate.Value);

            var result = await transactionsQuery.Include(x => x.Account)
                                                .Include(x => x.TransferAccount)
                                                .Include(x => x.Category)
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

