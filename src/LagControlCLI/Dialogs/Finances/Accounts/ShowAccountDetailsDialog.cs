using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Accounts
{
    internal class ShowAccountDetailsDialog(IAnsiConsole console, IMediator mediator) : DialogBase<IList<AccountBalanceDto>>(console), IShowAccountDetailsDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected async override Task ExecuteAsync(IList<AccountBalanceDto> accounts)
        {
            var choices = accounts.ToDictionary(a => a, a => a.Description + " | " + a.Balance.ToString("C"));

            var selected = SelectionPrompt.Ask(Console, Resource.SelectAccountPrompt, choices);

            var statement = await mediator.Send(new StatementQuery { AccountId = selected.Id });

            ShowDetails(selected, statement);

            Console.Prompt(new TextPrompt<string>(Resource.PressEnterToReturn.Color(Color.Grey)).AllowEmpty());
        }

        private void ShowDetails(AccountBalanceDto account, StatementDto statement)
        {
            var grid = new Grid();
            grid.AddColumn(new GridColumn().NoWrap());
            grid.AddColumn();

            void Row(string label, string? value) => grid.AddRow(new Markup($"{label}:".Color(Color.Grey)), new Markup(string.IsNullOrWhiteSpace(value) ? Resource.Dash : value));

            Row(Resource.AccountColumn, account.Description);
            Row(Resource.Balance, account.Balance.ToString("C"));
            Row(Resource.ExpectedBalance, account.ExpectedBalance.ToString("C"));
            Row(Resource.LastTransaction, account.LastTransactionDate?.ToString(Resource.DateFormat) ?? Resource.Dash);

            grid.AddRow(new Markup("---".Color(Color.Grey)), new Markup(""));

            Row(Resource.Period, $"{statement.StartDate.ToString(Resource.DateFormat)} {Resource.RangeConnector} {statement.EndDate.ToString(Resource.DateFormat)}");
            Row(Resource.StartBalance, statement.InitialBalance.ToString("C"));
            Row(Resource.EndBalance, statement.FinalBalance.ToString("C"));

            if (statement.PendingStatement is not null)
            {
                Row(Resource.PendingTotalIncome, statement.PendingStatement.TotalIncomeAmount.ToString("C"));
                Row(Resource.PendingTotalExpense, statement.PendingStatement.TotalExpenseAmount.ToString("C"));
                Row(Resource.PendingExpectedBalance, statement.PendingStatement.ExpectedBalance.ToString("C"));
            }

            Console.Write(new Panel(grid)
            {
                Header = new PanelHeader(Resource.AccountDetailsHeader, Justify.Left),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0)
            });
        }
    }
}
