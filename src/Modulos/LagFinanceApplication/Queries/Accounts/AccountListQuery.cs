using System.Collections.Generic;
using LagFinanceApplication.Dtos.Accounts;
using MediatR;

namespace LagFinanceApplication.Queries.Accounts
{
    public class AccountListQuery : IRequest<IList<AccountListDto>>
    {
    }
}

