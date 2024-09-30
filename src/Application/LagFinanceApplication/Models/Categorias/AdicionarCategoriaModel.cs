using LagFinanceDomain.Enum;

namespace LagFinanceApplication.Models.Categorias
{
    public class AdicionarCategoriaModel
    {
        public string Descricao { get; set; }

        public TipoCategoriaEnum Tipo { get; set; }
    }
}
