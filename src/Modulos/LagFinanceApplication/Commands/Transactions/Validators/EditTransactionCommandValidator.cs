using FluentValidation;

namespace LagFinanceApplication.Commands.Transactions.Validators
{
    public class EditTransactionCommandValidator : AbstractValidator<EditTransactionCommand>
    {
        public EditTransactionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
