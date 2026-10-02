using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Dtos.Categories
{
    public class CategoryListDto
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public CategoryTypeEnum Type { get; set; }

        public CategoryListDto? ParentCategory { get; set; }
    }
}

