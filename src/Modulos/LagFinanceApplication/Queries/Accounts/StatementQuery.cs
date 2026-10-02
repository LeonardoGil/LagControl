using LagFinanceApplication.Dtos.Accounts;
using MediatR;

namespace LagFinanceApplication.Queries.Accounts
{
    public class StatementQuery : IRequest<StatementDto>
    {
        public Guid AccountId { get; set; }

        private DateOnly? startDate;
        private DateOnly? endDate;

        public DateOnly StartDate
        {
            set => startDate = value;
            get => startDate ?? new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 01);
        }

        public DateOnly EndDate
        {
            set => endDate = value;
            get => endDate ?? DateOnly.FromDateTime(DateTime.Now);
        }
    }
}

