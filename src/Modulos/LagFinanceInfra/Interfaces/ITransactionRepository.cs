using LagBaseInfra;
using LagFinanceDomain.Entities;

namespace LagFinanceInfra.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        IQueryable<Transaction> GetTransactionsForDateRangeQuery(DateTime periodStart, DateTime periodEnd, bool includePreviousPending = false, params Guid[] accountsId);
    }
}

