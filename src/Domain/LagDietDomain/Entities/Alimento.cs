using LagBaseDomain;

namespace LagDietDomain.Entities
{
    public class Alimento : Entity
    {
        public string Descricao { get; set; }

        public int Kcal { get; set; }

        public double Proteinas { get; set; }

        public double Carboidratos { get; set; }

        public double Gorduras { get; set; }
    }
}
