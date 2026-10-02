using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Extensions.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Reports
{
    internal class StatementReportDialog(IAnsiConsole console, IMediator mediator) : DialogBase(console), IStatementReportDialog
    {
        private IList<AccountBalanceDto> Accounts { get; set; } = default!;

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingAccounts, async _ => Accounts = await mediator.Send(new AccountBalanceQuery()));
        }

        protected override async Task ExecuteAsync()
        {
            var choices = Accounts.ToDictionary(a => a, a => a.Description + " | " + a.Balance.ToString("C"));

            var selected = SelectionPrompt.Ask(Console, Resource.SelectAccountPrompt, choices);

            var start = DatePrompt.Ask(Console, Resource.DateLabel, options: DateDialogOptions.Options);
            var end = DatePrompt.Ask(Console, Resource.DateLabel, options: DateDialogOptions.Options);

            var query = new StatementQuery
            {
                AccountId = selected.Id,
                StartDate = DateOnly.FromDateTime(start),
                EndDate = DateOnly.FromDateTime(end)
            };

            var statement = default(StatementDto)!;
            
            await Console.LoadingAsync("Carregando extrato", async _ => statement = await mediator.Send(query));

            RenderStatement(selected, statement);

            Console.Prompt(new TextPrompt<string>(Resource.PressEnterToReturn.Color(Color.Grey)).AllowEmpty());
        }

        private void RenderStatement(AccountBalanceDto account, LagFinanceApplication.Dtos.Accounts.StatementDto statement)
        {
            var grid = new Grid();
            grid.AddColumn(new GridColumn().NoWrap());
            grid.AddColumn();

            RowLabel(string.Empty, string.Empty);
            RowLabel(Resource.AccountColumn, account.Description);
            RowLabel(Resource.Period, $"{statement.StartDate.ToString(Resource.DateFormat)} {Resource.RangeConnector} {statement.EndDate.ToString(Resource.DateFormat)}");

            var startBalanceMarkup = statement.InitialBalance.ToString("C").Color(statement.InitialBalance >= 0 ? Color.Green : Color.Red);
            grid.AddRow(new Markup(Resource.StartBalance.Color(Color.Grey)), new Markup(startBalanceMarkup));

            var finalBalanceMarkup = statement.FinalBalance.ToString("C").Color(statement.FinalBalance >= 0 ? Color.Green : Color.Red);
            grid.AddRow(new Markup(Resource.EndBalance.Color(Color.Grey)), new Markup(finalBalanceMarkup));

            Console.Write(new Panel(grid)
            {
                Header = new PanelHeader(Resource.AccountDetailsHeader, Justify.Left),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0)
            });

            foreach (var dayGroup in statement.DailyStatements.OrderBy(g => g.Day))
            {
                var title = dayGroup.Day.ToString(Resource.DateFormat);
                var table = TransactionExtensions.BuildTable(dayGroup.Transactions, title, account.Id);

                Console.Write(table);

                var dayEndMarkup = dayGroup.DayEndAmount.ToString("C").Color(dayGroup.DayEndAmount >= 0 ? Color.Green : Color.Red);
                Console.MarkupLine($"{Resource.EndBalance.Color(Color.Grey)}: {dayEndMarkup}\n");
            }

            if (statement.PendingStatement is not null && statement.PendingStatement.Transactions.Count > 0)
            {
                var pendingTable = TransactionExtensions.BuildTable(statement.PendingStatement.Transactions, Resource.Pending, account.Id);
                Console.Write(pendingTable);

                var pendingExpected = statement.PendingStatement.ExpectedBalance;
                var pendingExpectedMarkup = pendingExpected.ToString("C").Color(pendingExpected >= 0 ? Color.Green : Color.Red);
                Console.MarkupLine($"{Resource.PendingExpectedBalance.Color(Color.Grey)}: {pendingExpectedMarkup}\n");
            }

            var overallPanel = new Grid();
            overallPanel.AddColumn(new GridColumn().NoWrap());
            overallPanel.AddColumn();

            overallPanel.AddRow(new Markup(Resource.EndBalance.Color(Color.Grey)), new Markup(statement.FinalBalance.ToString("C").Color(statement.FinalBalance >= 0 ? Color.Green : Color.Red)));

            if (statement.PendingStatement is not null)
            {
                overallPanel.AddRow(new Markup(Resource.PendingExpectedBalance.Color(Color.Grey)), new Markup(statement.PendingStatement.ExpectedBalance.ToString("C").Color(statement.PendingStatement.ExpectedBalance >= 0 ? Color.Green : Color.Red)));
            }

            Console.Write(new Panel(overallPanel)
            {
                Header = new PanelHeader(Resource.AccountDetailsHeader, Justify.Left),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0)
            });

            void RowLabel(string label, string? value) => grid.AddRow(new Markup(string.IsNullOrEmpty(label) ? string.Empty : label.Color(Color.Grey)), new Markup(string.IsNullOrWhiteSpace(value) ? Resource.Dash : value));
        }
    }
}
