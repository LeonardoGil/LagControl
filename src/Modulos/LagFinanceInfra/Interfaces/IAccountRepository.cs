using LagBaseInfra;
using LagFinanceDomain.Entities;

namespace LagFinanceInfra.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<bool> HasAnyTransactionAsync(Guid accountId, CancellationToken cancellationToken = default);

        Task<string> GetDescriptionAsync(Guid accountId, CancellationToken cancellationToken = default);

        Task<decimal> GetPreviousBalanceAmountAsync(Guid accountId, DateTime date, bool includePending = false, CancellationToken cancellationToken = default);
    }
}

