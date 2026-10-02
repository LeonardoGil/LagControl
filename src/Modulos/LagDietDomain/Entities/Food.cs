using LagBaseDomain;
using LagDietDomain.Enums;

namespace LagDietDomain.Entities
{
    public class Food : Entity
    {
        public required string Description { get; set; }

        public MeasurementUnitEnum MeasurementUnit { get; set; }

        public double Portion { get; set; }

        public int Kcal { get; set; }

        public double Proteins { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }
    }
}

