using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceDomain.Enums;
using Spectre.Console;

namespace LagControlCLI.Extensions.Finances
{
    internal static class TransactionExtensions
    {
        internal static Table BuildTable(IList<TransactionGridDto> transactions, string? title = null, Guid? accountId = null)
        {
            var table = new Table
            {
                Title = new TableTitle(title ?? Resource.Transactions, new Style(decoration: Decoration.Bold)),
                Border = TableBorder.Rounded,
                Expand = true
            };

            table.ShowRowSeparators();

            table.AddColumn(new TableColumn(Resource.DataColumn).NoWrap());
            table.AddColumn(new TableColumn(Resource.Description));
            table.AddColumn(new TableColumn(Resource.ValueColumn).RightAligned().NoWrap());
            table.AddColumn(new TableColumn(Resource.TypeColumn).NoWrap());
            table.AddColumn(new TableColumn(Resource.Pending).NoWrap());
            table.AddColumn(new TableColumn(Resource.AccountColumn));
            table.AddColumn(new TableColumn(Resource.TransferAccountLabel));
            table.AddColumn(new TableColumn(Resource.CategoryColumn));

            foreach (var transaction in transactions.OrderByDescending(t => t.Date))
            {
                var type = GetTransactionType(transaction.Type);
                var amount = GetTransactionAmount(transaction, accountId);
                var pending = transaction.Pending ? Resource.Yes.Color(Color.Yellow) : Resource.No;
                
                table.AddRow(new Markup(transaction.Date.ToString(Resource.DateFormat)),
                             new Markup(TextOrDash(transaction.Description)),
                             new Markup(amount),
                             new Markup(type),
                             new Markup(pending),
                             new Markup(TextOrDash(transaction.Account)),
                             new Markup(TextOrDash(transaction.TransferAccount)),
                             new Markup(TextOrDash(transaction.Category)));
            }

            return table;
        }

        private static string TextOrDash(string? value) => string.IsNullOrWhiteSpace(value) ? Resource.Dash : Markup.Escape(value);

        private static string GetTransactionType(TransactionTypeEnum type) => type switch
        {
            TransactionTypeEnum.Income => Resource.IncomeLabel.Color(Color.Green),
            TransactionTypeEnum.Expense => Resource.ExpenseLabel.Color(Color.Red),
            TransactionTypeEnum.Transfer => Resource.TransferLabel.Color(Color.DeepSkyBlue3),
            _ => type.ToString()
        };

        private static string GetTransactionAmount(TransactionGridDto transaction, Guid? accountId)
        {
            var amount = transaction.Amount.ToString("C");

            var color = transaction.Type switch
            {
                TransactionTypeEnum.Income => Color.Green,
                TransactionTypeEnum.Expense => Color.Red,
                TransactionTypeEnum.Transfer when (!accountId.HasValue) => Color.DeepSkyBlue3,
                TransactionTypeEnum.Transfer when (transaction.AccountId == accountId) => Color.Red,
                TransactionTypeEnum.Transfer when (transaction.TransferAccountId == accountId) => Color.Green,
                _ => Color.White
            };

            return amount.Color(color);
        }
    }
}
