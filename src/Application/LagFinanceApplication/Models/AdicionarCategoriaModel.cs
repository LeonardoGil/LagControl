using LagFinanceDomain.Enum;

namespace LagFinanceApplication.Models
{
    public class AdicionarCategoriaModel
    {
        public string Descricao { get; set; }

        public TipoCategoriaEnum Tipo { get; set; }
    }
}
