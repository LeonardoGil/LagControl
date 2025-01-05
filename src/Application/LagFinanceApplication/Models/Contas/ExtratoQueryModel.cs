namespace LagFinanceApplication.Models.Contas
{
    public class ExtratoQueryModel
    {
        public Guid ContaId { get; set; }

        private DateOnly? dataInicio;
        private DateOnly? dataFim;

        public DateOnly DataInicio
        {
            set => dataInicio = value;
            get => dataInicio ?? new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 01);
        }

        public DateOnly DataFim
        {
            set => dataFim = value;
            get => dataFim ?? DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
