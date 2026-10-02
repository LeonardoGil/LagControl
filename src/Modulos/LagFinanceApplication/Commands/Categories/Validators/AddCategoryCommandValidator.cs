using FluentValidation;

namespace LagFinanceApplication.Commands.Categories.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
