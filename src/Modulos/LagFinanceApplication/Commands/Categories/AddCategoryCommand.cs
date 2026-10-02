using LagFinanceDomain.Enums;
using MediatR;

namespace LagFinanceApplication.Commands.Categories
{
    public class AddCategoryCommand : IRequest<Unit>
    {
        public required string Description { get; set; }

        public CategoryTypeEnum Type { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}

