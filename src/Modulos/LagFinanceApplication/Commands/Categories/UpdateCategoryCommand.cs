using MediatR;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Commands.Categories
{
    public record UpdateCategoryCommand : IRequest<Unit>
    {
        public required Guid Id { get; init; }
        public required string Description { get; init; }
        public required CategoryTypeEnum Type { get; init; }
        public Guid? ParentCategoryId { get; init; }
    }
}
