using LagBaseDomain;
using LagDietDomain.Enums;

namespace LagDietDomain.Entities
{
    public class RefeicaoAlimento : Entity
    {
        public Guid AlimentoId { get; set; }
        public virtual Alimento Alimento { get; set; }

        public Guid RefeicaoId { get; set; }
        public virtual Guid Refeicao { get; set; }

        public double Porcao { get; set; }

        public UnidadeMedidaEnum UnidadeMedida { get; set; }
    }
}
