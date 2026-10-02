using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class Transaction : Entity
    {
        public required string Description { get; set; }

        public string? Notes { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public TransactionTypeEnum TransactionType { get; set; }

        public bool Pending { get; set; }

        #region Relationships

        public Guid AccountId { get; set; }

        public virtual Account? Account { get; set; }

        public Guid? TransferAccountId { get; set; }

        public virtual Account? TransferAccount { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        #endregion

        public decimal BalanceAmount()
        {
            return TransactionType switch
            {
                TransactionTypeEnum.Income => Amount,
                
                TransactionTypeEnum.Expense or 
                TransactionTypeEnum.Transfer => -Math.Abs(Amount),
                
                _ => throw new NotImplementedException(),
            };
        }
    }
}

