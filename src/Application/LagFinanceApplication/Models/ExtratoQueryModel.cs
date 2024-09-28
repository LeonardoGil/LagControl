namespace LagFinanceApplication.Models
{
    public class ExtratoQueryModel
    {
        public Guid ContaId { get; set; }

        public DateOnly? DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
    }
}
