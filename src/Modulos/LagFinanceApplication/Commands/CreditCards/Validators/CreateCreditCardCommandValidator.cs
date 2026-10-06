using FluentValidation;

namespace LagFinanceApplication.Commands.CreditCards.Validators
{
    public class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
    {
        public CreateCreditCardCommandValidator()
        {
            RuleFor(x => x.HolderName).NotEmpty();
            RuleFor(x => x.CreditLimit).GreaterThan(0);
            RuleFor(x => x.AccountId).NotEmpty();

            When(x => x.ClosingDay.HasValue, () => RuleFor(x => x.ClosingDay).GreaterThanOrEqualTo(1).LessThanOrEqualTo(28));
            When(x => x.DueDay.HasValue, () => RuleFor(x => x.DueDay).GreaterThanOrEqualTo(1).LessThanOrEqualTo(28));
        }
    }
}
