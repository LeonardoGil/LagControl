using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class CreditCardInvoice : Entity
    {
        public DateTime ClosingDate { get; set; }

        public DateTime DueDate { get; set; }

        public CreditCardInvoiceStatusEnum Status { get; set; } = CreditCardInvoiceStatusEnum.Open;

        public Guid CreditCardId { get; set; }

        public virtual CreditCard? CreditCard { get; set; }

        public virtual List<CreditCardTransaction>? Transactions { get; set; }

        public decimal TotalAmount()
        {
            return Transactions?.Sum(t => t.Amount) ?? decimal.Zero;
        }

        public bool IsPaid()
        {
            return Status == CreditCardInvoiceStatusEnum.Paid;
        }
    }
}
