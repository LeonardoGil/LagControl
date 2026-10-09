using FluentValidation;

namespace LagFinanceApplication.Commands.CreditCards.Validators
{
    public class AddCreditCardTransactionCommandValidator : AbstractValidator<AddCreditCardTransactionCommand>
    {
        public AddCreditCardTransactionCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.CreditCardId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();

            When(x => x.Installments.HasValue, () => RuleFor(x => x.Installments).GreaterThan(1));
        }
    }
}
