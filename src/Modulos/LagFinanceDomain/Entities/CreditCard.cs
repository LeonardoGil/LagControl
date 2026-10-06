using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class CreditCard : Entity
    {
        public required string HolderName { get; set; }

        public int ClosingDay { get; set; }

        public int DueDay { get; set; }

        public required decimal CreditLimit { get; set; }

        public bool Active { get; set; } = true;

        public Guid AccountId { get; set; }

        public virtual Account? Account { get; set; }

        public virtual List<CreditCardInvoice>? Invoices { get; set; }

        public virtual List<CreditCardTransaction>? Transactions { get; set; }

        public decimal AvailableCredit()
        {
            ArgumentNullException.ThrowIfNull(Invoices, nameof(Invoices));

            var outstandingInvoices = Invoices.Where(i => i.Status != CreditCardInvoiceStatusEnum.Paid);

            var used = decimal.Zero;

            if (outstandingInvoices.Any())
            {
                used = outstandingInvoices.SelectMany(x => x.Transactions ?? [])
                                          .Where(t => !t.Pending)
                                          .Sum(t => t.Amount);
            }
            
            return CreditLimit - used;
        }
    }
}
