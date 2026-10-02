using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceInfra.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Handlers.Accounts
{
    public class AccountListHandler(IAccountRepository accountRepository) : IRequestHandler<AccountListQuery, IList<AccountListDto>>
    {
        public async Task<IList<AccountListDto>> Handle(AccountListQuery request, CancellationToken cancellationToken)
        {
            var accounts = await accountRepository.Get()
                                                  .AsNoTracking()
                                                  .Select(account => new AccountListDto
                                                  {
                                                      Id = account.Id,
                                                      Description = account.Description
                                                  })
                                                  .ToListAsync(cancellationToken);

            return accounts;
        }
    }
}

