using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Accounts
{
    public class AccountBalanceHandler(IAccountRepository accountRepository) : IRequestHandler<AccountBalanceQuery, IList<AccountBalanceDto>>
    {
        public async Task<IList<AccountBalanceDto>> Handle(AccountBalanceQuery query, CancellationToken cancellationToken)
        {
            var accounts = accountRepository.Get()
                                            .Where(x => query.AccountIds == null || query.AccountIds.Contains(x.Id))
                                            .AsNoTracking();

            var models = await accounts.Include(x => x.Transactions)
                                       .Select(account => new AccountBalanceDto
                                       {
                                           Id = account.Id,
                                           Description = account.Description,
                                           LastTransactionDate = account.Transactions!.Where(x => !x.Pending)
                                                                                      .OrderByDescending(x => x.Date)
                                                                                      .Select(x => (DateTime?)x.Date)
                                                                                      .FirstOrDefault()
                                       })
                                       .ToListAsync(cancellationToken);

            var date = DateTime.Now.Date.AddDays(1);
            foreach (var model in models)
            {
                model.Balance = await accountRepository.GetPreviousBalanceAmountAsync(model.Id, date, cancellationToken: cancellationToken);
                model.ExpectedBalance = await accountRepository.GetPreviousBalanceAmountAsync(model.Id, date, includePending: true, cancellationToken: cancellationToken);
            }

            return models;
        }
    }
}

