using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Extensions.Finances;
using LagControlCLI.Options.TransactionDialog;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Transactions;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class ListTransactionDialog(IAnsiConsole console, 
                                         IMediator mediator, 
                                         IListTransactionFilterDialog listTransactionFilterDialog,
                                         IShowTransactionDetailsDialog showTransactionDetailsDialog) : LoopDialogBase(console), IListTransactionDialog
    {
        private ListTransactionsQuery query = ListTransactionsQuery.Default();
        private IList<TransactionGridDto> transactions = [];

        protected override async Task ExecuteAsync()
        {
            RenderFilterSummary();

            if (transactions.Count == 0)
            {
                Console.MarkupLine(Resource.NoTransactionsFound.Color(Color.Yellow));
            }
            else
            {
                var transactionTable = TransactionExtensions.BuildTable(transactions);

                Console.Write(transactionTable);
            }

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, TransactionListDialogOption.Options);

            switch (action)
            {
                case TransactionListDialogOption.TransactionListDialogEnum.Filter:
                    query = await listTransactionFilterDialog.ShowAndReturn(query);
                    await LoadAsync();
                    break;

                case TransactionListDialogOption.TransactionListDialogEnum.Refresh:
                    break;

                case TransactionListDialogOption.TransactionListDialogEnum.Details:
                    await showTransactionDetailsDialog.Show(transactions);
                    break;

                case TransactionListDialogOption.TransactionListDialogEnum.Exit:
                    Stop();
                    break;
            }
        }

        protected override async Task LoadAsync()
        {
            try
            {
                await Console.LoadingAsync(Resource.LoadingTransactions, async _ =>
                {
                    transactions = await mediator.Send(query);
                });
            }
            catch (Exception ex)
            {
                Console.MarkupLine(Resource.ErrorLoadingTransactions.Color(Color.Red));
                Console.MarkupLine(ex.Message.Color(Color.Grey));

                var retry = Console.Confirm(Resource.RetryPrompt, defaultValue: true);

                if (!retry)
                {
                    Stop();
                }
            }
        }


        private Dictionary<TransactionListDialogOption.TransactionListDialogEnum, string> BuildOptions()
        {
            var options = TransactionListDialogOption.Options;

            if (transactions.Count == 0)
            {
                options.Remove(TransactionListDialogOption.TransactionListDialogEnum.Details);
            }

            return options;
        }

        private void RenderFilterSummary()
        {
            var grid = new Grid();
            grid.AddColumn(new GridColumn().NoWrap());
            grid.AddColumn();

            string DateOrDash(DateTime? d) => d.HasValue ? d.Value.ToString(Resource.DateFormat) : Resource.Dash;
            string TextOrDash(string? s) => string.IsNullOrWhiteSpace(s) ? Resource.Dash : s;

            grid.AddRow(new Markup(Resource.Period.Color(Color.Grey)), new Markup($"{DateOrDash(query.StartDate)} {Resource.RangeConnector} {DateOrDash(query.EndDate)}"));
            grid.AddRow(new Markup(Resource.Description.Color(Color.Grey)), new Markup(Markup.Escape(TextOrDash(query.Description))));
            grid.AddRow(new Markup(Resource.Pending.Color(Color.Grey)), new Markup(query.PendingOnly ? Resource.Pending.Color(Color.Yellow) : Resource.No));
            grid.AddRow(new Markup(Resource.Accounts.Color(Color.Grey)), new Markup(query.AccountIds is { Count: > 0 } ? query.AccountIds.Count.ToString() : Resource.Dash));
            grid.AddRow(new Markup(Resource.Categories.Color(Color.Grey)), new Markup(query.CategoryIds is { Count: > 0 } ? query.CategoryIds.Count.ToString() : Resource.Dash));

            var countsByType = transactions.GroupBy(t => t.Type).ToDictionary(g => g.Key, g => g.Count());

            countsByType.TryGetValue(TransactionTypeEnum.Income, out var incomeCount);
            countsByType.TryGetValue(TransactionTypeEnum.Expense, out var expenseCount);
            countsByType.TryGetValue(TransactionTypeEnum.Transfer, out var transferCount);

            var resume = new Markup($"{Resource.Found.Color(Color.Grey)}: {transactions.Count}  {"|".Color(Color.Grey)} {Resource.IncomeLabel.Color(Color.Green)}: {incomeCount}  {"|".Color(Color.Grey)} {Resource.ExpenseLabel.Color(Color.Red)}: {expenseCount}  {"|".Color(Color.Grey)} {Resource.TransferLabel.Color(Color.DeepSkyBlue3)}: {transferCount}");
            var body = new Rows(grid, new Text(""), resume);
            var panel = new Panel(body)
            {
                Header = new PanelHeader(Resource.Filters, Justify.Center),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0),
                Expand = true
            };

            Console.Write(panel);
        }
    }
}
