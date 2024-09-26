using LagBaseDomain;
using LagFinanceDomain.Enum;

namespace LagFinanceDomain.Domain
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }

        public TipoCategoriaEnum Tipo { get; set; }
    }
}
