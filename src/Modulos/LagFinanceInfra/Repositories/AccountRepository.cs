using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LagFinanceInfra.Repositories
{
    public class AccountRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, Account>(context), IAccountRepository
    {
        public async Task<string> GetDescriptionAsync(Guid accountId, CancellationToken cancellationToken = default)
        {
            return await Get().AsNoTracking()
                              .Where(x => x.Id == accountId)
                              .Select(x => x.Description)
                              .SingleAsync(cancellationToken);
        }

        public async Task<decimal> GetPreviousBalanceAmountAsync(Guid accountId, DateTime date, bool includePending = false, CancellationToken cancellationToken = default)
        {
            return await _context.Transaction.AsNoTracking()
                                             .Where(t => t.AccountId == accountId || t.TransferAccountId == accountId)
                                             .Where(t => includePending || !t.Pending)
                                             .Where(t => t.Date.Date < date.Date)
                                             .SumAsync(t => t.TransactionType == TransactionTypeEnum.Income ? t.Amount :
                                                            t.TransactionType == TransactionTypeEnum.Expense ? -t.Amount : 
                                                            t.TransactionType == TransactionTypeEnum.Transfer ? (t.TransferAccountId == accountId ? t.Amount : -t.Amount) : decimal.Zero, cancellationToken);
        }

        public async Task<bool> HasAnyTransactionAsync(Guid accountId, CancellationToken cancellationToken = default)
        {
            return await _context.Transaction.AsNoTracking().AnyAsync(t => t.AccountId == accountId || t.TransferAccountId == accountId, cancellationToken);
        }
    }
}

