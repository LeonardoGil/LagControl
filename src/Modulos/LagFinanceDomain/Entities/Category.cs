using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class Category : Entity
    {
        public required string Description { get; set; }

        public CategoryTypeEnum Type { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }

        public ICollection<Category> Children { get; set; } = [];
    }
}

