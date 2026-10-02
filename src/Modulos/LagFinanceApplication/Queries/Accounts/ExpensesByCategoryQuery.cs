using LagFinanceApplication.Dtos.Accounts;
using MediatR;

namespace LagFinanceApplication.Queries.Accounts
{
    public record ExpensesByCategoryQuery : IRequest<ExpensesByCategoryDto>
    {
        public List<Guid>? AccountId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}

