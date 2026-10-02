using LagBaseInfra;
using LagFinanceDomain.Entities;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Repositories
{
    public class TransactionRepository(LagFinanceDbContext context) : BaseRepository<LagFinanceDbContext, Transaction>(context), ITransactionRepository
    {
        public IQueryable<Transaction> GetTransactionsForDateRangeQuery(DateTime periodStart, DateTime periodEnd, bool includePreviousPending = false, params Guid[] accountsId)
        {
            if (accountsId.Length == 0)
                throw new Exception();

            var query = Get().AsNoTracking()
                             .Include(t => t.Category)
                             .Include(t => t.TransferAccount)
                             .Include(t => t.Account)
                             .Where(t => accountsId.Contains(t.AccountId) || accountsId.Contains(t.TransferAccountId ?? Guid.Empty));

            if (includePreviousPending)
            {
                query = query.Where(t => t.Date >= periodStart && t.Date < periodEnd.Date || (t.Pending && t.Date < periodStart));
            }
            else
            {
                query = query.Where(t => t.Date >= periodStart && t.Date < periodEnd.Date);
            }

            return query;
        }
    }
}

