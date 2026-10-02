using System.Collections.Generic;
using LagFinanceApplication.Dtos.Accounts;
using MediatR;

namespace LagFinanceApplication.Queries.Accounts
{
    public class AccountBalanceQuery : IRequest<IList<AccountBalanceDto>>
    {
        public IEnumerable<Guid>? AccountIds { get; set; }
    }
}

