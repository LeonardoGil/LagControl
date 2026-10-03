using LagBaseDomain;

namespace LagFinanceDomain.Entities
{
    public class CreditCardTransaction : Entity
    {
        public required string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool Pending { get; set; }

        public string? Merchant { get; set; }

        public int Installments { get; set; } = 1;

        public int? InstallmentNumber { get; set; }

        public Guid CreditCardId { get; set; }
        public virtual CreditCard? CreditCard { get; set; }

        public Guid? InvoiceId { get; set; }
        public virtual CreditCardInvoice? Invoice { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
