using FluentValidation;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Commands.Transactions.Validators
{
    public class AddTransferTransactionCommandValidator : AbstractValidator<AddTransferTransactionCommand>
    {
        public AddTransferTransactionCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.TransferAccountId).NotEmpty().NotEqual(x => x.AccountId);
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
