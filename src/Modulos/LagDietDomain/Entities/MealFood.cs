using LagBaseDomain;
using LagDietDomain.Enums;

namespace LagDietDomain.Entities
{
    public class MealFood : Entity
    {
        public Guid FoodId { get; set; }
        public virtual Food? Food { get; set; }

        public Guid MealId { get; set; }
        public virtual Meal? Meal { get; set; }

        public double Portion { get; set; }

        public MeasurementUnitEnum MeasurementUnit { get; set; }
    }
}

