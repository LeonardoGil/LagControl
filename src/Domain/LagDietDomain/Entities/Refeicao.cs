using LagBaseDomain;

namespace LagDietDomain.Entities
{
    public class Refeicao : Entity
    {
        public string Descricao { get; set; }

        public virtual List<RefeicaoAlimento> Alimentos { get; set; }
    }
}
