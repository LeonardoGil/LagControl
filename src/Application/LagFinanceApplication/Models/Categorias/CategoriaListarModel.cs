namespace LagFinanceApplication.Models.Categorias
{
    public class CategoriaListarModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public CategoriaListarModel? CategoriaPai { get; set; }
    }
}
