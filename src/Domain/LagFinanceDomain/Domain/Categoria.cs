using LagFinanceDomain.Enum;

namespace LagFinanceDomain.Domain
{
    public class Categoria
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public TipoCategoriaEnum Tipo { get; set; }
    }
}
