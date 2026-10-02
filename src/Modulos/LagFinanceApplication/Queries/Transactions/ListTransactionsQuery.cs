using LagFinanceApplication.Dtos.Transactions;
using LagFinanceDomain.Enums;
using MediatR;

namespace LagFinanceApplication.Queries.Transactions
{
    public class ListTransactionsQuery : IRequest<IList<TransactionGridDto>>
    {
        public string? Description { get; set; }

        public IList<Guid>? AccountIds { get; set; }

        public IList<Guid>? CategoryIds { get; set; }

        public bool PendingOnly { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TransactionTypeEnum? Type { get; set; }

        public static ListTransactionsQuery Default()
        {
            var dateNow = DateTime.Now;
            var startDate = new DateTime(dateNow.Year, dateNow.Month, 1);
            var endDate = new DateTime(dateNow.Year, dateNow.Month, 1).AddMonths(1).AddSeconds(-1);

            return new ListTransactionsQuery
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}

