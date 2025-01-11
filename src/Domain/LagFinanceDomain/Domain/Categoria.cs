using LagBaseDomain;
using LagFinanceDomain.Enum;

namespace LagFinanceDomain.Domain
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }

        public TipoCategoriaEnum Tipo { get; set; }

        public Guid? CategoriaPaiId { get; set; }
        public virtual Categoria? CategoriaPai { get; set; }
    }
}
