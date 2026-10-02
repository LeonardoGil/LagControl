using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Accounts
{
    public class StatementHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository) : IRequestHandler<StatementQuery, StatementDto>
    {
        public async Task<StatementDto> Handle(StatementQuery query, CancellationToken cancellationToken)
        {
            var hasAnyTransaction = await accountRepository.HasAnyTransactionAsync(query.AccountId, cancellationToken);

            if (!hasAnyTransaction)
                throw new Exception("Account has no transactions");

            var periodStart = query.StartDate.ToDateTime(TimeOnly.MinValue);
            var periodEndExclusive = query.EndDate.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var accountDescription = await accountRepository.GetDescriptionAsync(query.AccountId, cancellationToken);

            var previousBalanceAmount = await accountRepository.GetPreviousBalanceAmountAsync(query.AccountId, periodStart, cancellationToken: cancellationToken);

            var transactions = await transactionRepository.GetTransactionsForDateRangeQuery(periodStart, periodEndExclusive, includePreviousPending: true, accountsId: query.AccountId).ToListAsync(cancellationToken);

            return new StatementDto(query.AccountId, accountDescription, transactions, query.StartDate, query.EndDate, previousBalanceAmount);
        }
    }
}

