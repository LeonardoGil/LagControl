namespace LagFinanceApplication.Models
{
    public class ExtratoModel
    {
        public string Conta { get; set; }

        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }

        public IList<ExtratoGroupModel> ExtratosDia { get; set; }
        public IList<MovimentacaoModel> Movimentacoes { get => ExtratosDia.SelectMany(x => x.Movimentacoes).ToList(); }
    }

    public class ExtratoGroupModel
    {
        public DateOnly Dia { get; set; }

        public IList<MovimentacaoModel> Movimentacoes { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorInicialDia { get; set; }
        public decimal ValorFinalDia { get; set; }
    }
}
