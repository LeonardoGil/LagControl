namespace LagFinanceApplication.Models.Movimentacoes
{
    public class EditarMovimentaoModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public bool Pendente { get; set; }

        public Guid ContaId { get; set; }

        public Guid CategoriaId { get; set; }
    }
}
