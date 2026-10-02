using LagBaseDomain;

namespace LagDietDomain.Entities
{
    public class Meal : Entity
    {
        public required string Description { get; set; }

        public virtual List<MealFood> Foods { get; set; } = [];
    }
}

