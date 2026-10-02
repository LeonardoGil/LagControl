using LagFinanceApplication.Dtos.Transactions;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Dtos.Accounts
{
    public record ExpensesByCategoryDto
    {
        public required IList<ExpensesByCategoryGroupDto> ExpensesByCategoryGroup { get; set; }
    }

    public record ExpensesByCategoryGroupDto
    {
        public required string Category { get; init; }

        public required CategoryTypeEnum Type { get; init; }

        public required IList<TransactionGridDto>? Transactions { get; init; }

        public decimal TotalAmount { get => Transactions?.Sum(x => x.Amount) ?? 0; }
    }
}

