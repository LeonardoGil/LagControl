using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options.TransactionDialog;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Transactions;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class ShowTransactionDetailsDialog(IAnsiConsole console, IEditTransactionDialog editTransactionDialog) : DialogBase<IList<TransactionGridDto>>(console), IShowTransactionDetailsDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(IList<TransactionGridDto> transactions)
        {
            var choices = transactions.OrderByDescending(t => t.Date).ToDictionary(t => t, t => $"{t.Date.ToString(Resource.DateFormat)} | {t.Description} | {t.Amount:C}");
            
            var selected = SelectionPrompt.Ask(Console, Resource.SelectTransactionPrompt, choices);

            ShowDetails(selected);

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, ShowTransactionDetailsDialogOptions.Options);

            switch (action)
            {
                case ShowTransactionDetailsDialogOptions.ShowTransactionDetailsDialogEnum.Edit:
                    await editTransactionDialog.Show(selected);
                    break;
            }
        }

        private void ShowDetails(TransactionGridDto transactions)
        {
            var grid = new Grid();
            
            grid.AddColumn(new GridColumn().NoWrap());
            grid.AddColumn();

            void Row(string label, string? value) => grid.AddRow(new Markup(label.Color(Color.Grey)), new Markup(string.IsNullOrWhiteSpace(value) ? Resource.Dash : value));

            Row(Resource.Id, transactions.Id.ToString());
            Row(Resource.DescriptionLabel, transactions.Description);
            Row(Resource.NotesLabel, transactions.Notes);
            Row(Resource.DateLabel, transactions.Date.ToString(Resource.DateFormat));
            Row(Resource.TypeLabel, transactions.Type.ToString());
            Row(Resource.ValueLabel, transactions.Amount.ToString("C"));
            Row(Resource.BalanceAfter, transactions.BalanceAmount.ToString("C"));
            Row(Resource.Pending, transactions.Pending ? Resource.Yes : Resource.No);
            Row(Resource.AccountColumn, transactions.Account);
            Row(Resource.CategoryColumn, transactions.Category);
            Row(Resource.TransferAccountLabel, transactions.TransferAccount);

            Console.Write(new Panel(grid)
            {
                Header = new PanelHeader(Resource.Details, Justify.Left),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0)
            });
        }
    }
}
