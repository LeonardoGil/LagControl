using FluentValidation;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Commands.Transactions.Validators
{
    public class AddTransactionCommandValidator : AbstractValidator<AddTransactionCommand>
    {
        public AddTransactionCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Type).NotEqual(TransactionTypeEnum.Transfer);
        }
    }
}
