using LagFinanceApplication.Dtos.Transactions;
using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;

namespace LagFinanceApplication.Dtos.Accounts
{
    public class StatementDto
    {
        public Guid AccountId { get; set; }

        public string Account { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public decimal InitialBalance { get; set; }
        public decimal FinalBalance { get; set; }

        public PendingStatementDto? PendingStatement { get; set; }

        public IList<StatementGroupDto> DailyStatements { get; set; }

        public StatementDto(Guid accountId, string account, IList<Transaction> transactions, DateOnly startDate, DateOnly endDate, decimal previousBalanceAmount = decimal.Zero)
        {
            AccountId = accountId;
            Account = account;
            DailyStatements = BuildStatementGroup(transactions, previousBalanceAmount);

            StartDate = startDate;
            EndDate = endDate;

            InitialBalance = previousBalanceAmount;
            FinalBalance = DailyStatements.LastOrDefault()?.DayEndAmount ?? previousBalanceAmount;

            PendingStatement = BuildPendingStatement(transactions);
        }

        private decimal BalanceAmountForStatement(Transaction transaction)
        {
            var absAmount = Math.Abs(transaction.Amount);

            return transaction.TransactionType switch
            {
                TransactionTypeEnum.Income => absAmount,
                TransactionTypeEnum.Expense => -absAmount,
                TransactionTypeEnum.Transfer when AccountId != Guid.Empty && transaction.TransferAccountId == AccountId => absAmount,
                TransactionTypeEnum.Transfer => -absAmount,
                _ => throw new NotImplementedException(),
            };
        }

        private PendingStatementDto? BuildPendingStatement(IList<Transaction> transactions)
        {
            var pendingTransactions = transactions.Where(x => x.Pending);

            if (!pendingTransactions.Any())
                return null;

            var statementPendingTransactions = pendingTransactions.ToArray();

            var income = statementPendingTransactions
                .Where(x => x.TransactionType == TransactionTypeEnum.Income || (x.TransactionType == TransactionTypeEnum.Transfer && AccountId != Guid.Empty && x.TransferAccountId == AccountId))
                .Sum(x => Math.Abs(x.Amount));

            var expenses = statementPendingTransactions
                .Where(x => x.TransactionType == TransactionTypeEnum.Expense || (x.TransactionType == TransactionTypeEnum.Transfer && (AccountId == Guid.Empty || x.TransferAccountId != AccountId)))
                .Sum(x => Math.Abs(x.Amount));

            var totalAmount = statementPendingTransactions.Sum(BalanceAmountForStatement);

            return new PendingStatementDto
            {
                Transactions = pendingTransactions.Select(mov => new TransactionGridDto
                {
                    Id = mov.Id,
                    Account = mov.Account?.Description ?? string.Empty,
                    AccountId = mov.AccountId,
                    Category = mov.Category?.Description ?? string.Empty,
                    CategoryId = mov.CategoryId,
                    TransferAccount = mov.TransferAccount?.Description ?? string.Empty,
                    TransferAccountId = mov.TransferAccountId,
                    Date = mov.Date,
                    Description = mov.Description,
                    Notes = mov.Notes,
                    Pending = mov.Pending,
                    Type = mov.TransactionType,
                    Amount = mov.Amount
                })
                .ToList(),

                TotalExpenseAmount = expenses,
                TotalIncomeAmount = income,

                ExpectedBalance = FinalBalance + totalAmount
            };
        }

        public IList<StatementGroupDto> BuildStatementGroup(IList<Transaction> transactions, decimal previousBalance = 0)
        {
            var dailyTransactions = transactions.Where(x => !x.Pending)
                                                .GroupBy(x => x.Date.Date)
                                                .Select(x => new StatementGroupDto
                                                {
                                                    Day = DateOnly.FromDateTime(x.Key),
                                                    Transactions = x.Select(mov => new TransactionGridDto
                                                    {
                                                        Id = mov.Id,
                                                        Account = mov.Account?.Description ?? string.Empty,
                                                        AccountId = mov.AccountId,
                                                        Category = mov.Category?.Description ?? string.Empty,
                                                        CategoryId = mov.CategoryId,
                                                        TransferAccount = mov.TransferAccount?.Description ?? string.Empty,
                                                        TransferAccountId = mov.TransferAccountId,
                                                        Date = mov.Date,
                                                        Description = mov.Description,
                                                        Notes = mov.Notes,
                                                        Pending = mov.Pending,
                                                        Type = mov.TransactionType,
                                                        Amount = mov.Amount,
                                                        BalanceAmount = BalanceAmountForStatement(mov)
                                                    }).ToList(),
                                                })
                                                .OrderBy(x => x.Day)
                                                .ToArray();

            var initialAmount = previousBalance;

            foreach (var dailyTransaction in dailyTransactions)
            {
                var totalAmount = dailyTransaction.Transactions.Sum(x => x.BalanceAmount);
                var finalAmount = initialAmount + totalAmount;
                dailyTransaction.TotalAmount = totalAmount;
                dailyTransaction.DayStartAmount = initialAmount;
                dailyTransaction.DayEndAmount = finalAmount;

                initialAmount = finalAmount;
            }

            return dailyTransactions;
        }
    }

    public class StatementGroupDto
    {
        public DateOnly Day { get; set; }

        public required IList<TransactionGridDto> Transactions { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DayStartAmount { get; set; }
        public decimal DayEndAmount { get; set; }
    }

    public class PendingStatementDto
    {
        public required IList<TransactionGridDto> Transactions { get; set; }

        public decimal TotalExpenseAmount { get; set; }
        public decimal TotalIncomeAmount { get; set; }

        public decimal ExpectedBalance { get; set; }
    }
}

