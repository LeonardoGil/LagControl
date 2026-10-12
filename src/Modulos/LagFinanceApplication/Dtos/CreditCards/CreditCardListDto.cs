namespace LagFinanceApplication.Dtos.CreditCards
{
    public class CreditCardListDto
    {
        public string? HolderName { get; set; }
        public string? Account { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal AvailableLimit { get; set; }
    }
}
