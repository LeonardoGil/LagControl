using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AccountsDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Accounts
{
    internal class AccountsDialog(IAnsiConsole console, IMediator mediator, IAddAccountDialog addAccountDialog, IShowAccountDetailsDialog showAccountDetailsDialog) : LoopDialogBase(console), IAccountsDialog
    {
        protected IList<AccountBalanceDto> Accounts { get; set; } = default!;

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingAccounts, async _ =>
            {
                Accounts = await mediator.Send(new AccountBalanceQuery());
            });
        }

        protected override async Task ExecuteAsync()
        {
            RenderAccounts();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, AccountsDialogOptions.Options);

            switch (action)
            {
                case AccountsDialogOptionEnum.Detail:
                    await showAccountDetailsDialog.Show(Accounts);
                    break;

                case AccountsDialogOptionEnum.AddAccount:
                    await addAccountDialog.Show();
                    break;

                case AccountsDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }

        private void RenderAccounts()
        {
            var panels = Accounts.OrderBy(a => a.Description)
                                 .Select(acc =>
                                 {
                                     var grid = new Grid();
                                     grid.AddColumn(new GridColumn().NoWrap());
                                     grid.AddColumn();

                                     void Row(string label, string? value) => grid.AddRow(new Markup($"{label}:".Color(Color.Grey)), new Markup(string.IsNullOrWhiteSpace(value) ? Resource.Dash : value));
                                     void RowEmpty() => grid.AddRow(new Text(string.Empty));

                                     RowEmpty();
                                     Row(Resource.Balance, acc.Balance.ToString("C"));
                                     Row(Resource.ExpectedBalance, acc.ExpectedBalance.ToString("C"));
                                     Row(Resource.LastTransaction, acc.LastTransactionDate?.ToString(Resource.DateFormat) ?? Resource.Dash);
                                     RowEmpty();

                                     return new Panel(grid)
                                     {
                                         Header = new PanelHeader(Markup.Escape(acc.Description)),
                                         Border = BoxBorder.Rounded,
                                         Padding = new Padding(2),
                                         Expand = true
                                     };
                                 })
                                 .ToArray();

            var columns = new Columns(panels) { Expand = true };

            Console.Write(new Panel(columns)
            {
                Header = new PanelHeader(string.Empty, Justify.Center),
                Border = BoxBorder.None,
                Padding = new Padding(2),
                Expand = true,
            });
        }
    }
}
