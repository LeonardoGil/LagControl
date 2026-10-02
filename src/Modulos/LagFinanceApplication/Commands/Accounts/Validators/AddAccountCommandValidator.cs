using FluentValidation;

namespace LagFinanceApplication.Commands.Accounts.Validators
{
    public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
    {
        public AddAccountCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.InitialBalance).GreaterThanOrEqualTo(0);
        }
    }
}
