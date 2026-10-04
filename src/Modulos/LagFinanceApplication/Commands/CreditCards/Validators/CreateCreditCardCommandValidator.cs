using FluentValidation;

namespace LagFinanceApplication.Commands.CreditCards.Validators
{
    public class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
    {
        public CreateCreditCardCommandValidator()
        {
            RuleFor(x => x.HolderName).NotEmpty();
            RuleFor(x => x.ClosingDay).GreaterThanOrEqualTo(1).LessThanOrEqualTo(28);
            RuleFor(x => x.CreditLimit).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AccountId).NotEmpty();
        }
    }
}
