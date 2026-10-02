using LagBaseDomain;
using LagFinanceDomain.Enums;

namespace LagFinanceDomain.Entities
{
    public class Account : Entity
    {
        public required string Description { get; set; }

        public virtual List<Transaction>? Transactions { get; set; }

        public decimal Balance()
        {
            if (Transactions is null)
                return decimal.Zero;

            var income = Transactions.Where(x => !x.Pending && x.TransactionType == TransactionTypeEnum.Income).Sum(x => x.Amount);
            var expenses = Transactions.Where(x => !x.Pending && x.TransactionType == TransactionTypeEnum.Expense).Sum(x => x.Amount);

            return income - expenses;
        }

        public decimal ExpectedBalance()
        {
            if (Transactions is null)
                return decimal.Zero;

            var income = Transactions.Where(x => x.TransactionType == TransactionTypeEnum.Income).Sum(x => x.Amount);
            var expenses = Transactions.Where(x => x.TransactionType == TransactionTypeEnum.Expense).Sum(x => x.Amount);

            return income - expenses;
        }

        public DateTime? LastTransactionDate()
        {
            return Transactions?.OrderByDescending(x => x.Date).Select(x => x.Date).LastOrDefault() ?? default;
        }
    }
}

