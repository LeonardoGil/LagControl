using LagBaseDomain;

namespace LagFinanceDomain.Entities
{
    public class CreditCard : Entity
    {
        public required string HolderName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal CreditLimit { get; set; }

        public bool Active { get; set; } = true;

        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }

        public virtual List<CreditCardInvoice>? Invoices { get; set; }

        public virtual List<CreditCardTransaction>? Transactions { get; set; }

        public decimal AvailableCredit()
        {
            var used = Transactions?.Where(t => !t.Pending).Sum(t => t.Amount) ?? decimal.Zero;
            return CreditLimit - used;
        }
    }
}
