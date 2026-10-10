using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class CreditCardInvoice : Entity
    {
        public int ReferenceMonth { get; set; }

        public int ReferenceYear { get; set; }

        public DateOnly OpeningDate { get; set; }

        public DateOnly ClosingDate { get; set; }

        public DateOnly DueDate { get; set; }

        public CreditCardInvoiceStatusEnum Status { get; set; } = CreditCardInvoiceStatusEnum.Open;

        public Guid CreditCardId { get; set; }

        public virtual CreditCard? CreditCard { get; set; }

        public virtual List<CreditCardTransaction>? Transactions { get; set; }

        public Guid? PaymentId { get; set; }

        public virtual Transaction? Payment { get; set; }

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
