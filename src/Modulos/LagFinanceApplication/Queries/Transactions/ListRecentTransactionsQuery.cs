using LagFinanceApplication.Dtos.Transactions;
using MediatR;

namespace LagFinanceApplication.Queries.Transactions
{
    public class ListRecentTransactionsQuery : IRequest<IList<TransactionGridDto>>
    {
        public IList<Guid>? AccountIds { get; set; }

        public int Total { get; set; } = 5;
    }
}

