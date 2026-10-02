using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options.TransactionDialog;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Dtos.Categories;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceApplication.Queries.Categories;
using LagFinanceApplication.Queries.Transactions;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.TransactionDialog.TransactionFilterDialogOption;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class ListTransactionFilterDialog(IAnsiConsole console, IMediator mediator) : DialogAndReturnBase<ListTransactionsQuery, ListTransactionsQuery>(console), IListTransactionFilterDialog
    {
        protected IList<AccountListDto> Accounts { get; set; } = default!;
        protected IList<CategoryListDto> Categories { get; set; } = default!;
        protected Dictionary<Guid, string> AccountDic { get; set; } = default!;
        protected Dictionary<Guid, string> CategoriesDic { get; set; } = default!;

        protected override Task<ListTransactionsQuery> ExecuteAndReturnAsync(ListTransactionsQuery query)
        {
            do
            {
                RenderFilterSummary(query);

                var action = SelectionPrompt.Ask(Console, string.Empty, TransactionFilterDialogOption.Options);

                switch (action)
                {
                    case ListTransactionFilterDialogOptionEnum.Description:
                        query.Description = TextPrompt.Ask(Console, Resource.Description);
                        break;

                    case ListTransactionFilterDialogOptionEnum.Date:
                        query.StartDate = DatePrompt.Ask(Console, Resource.DateStartPrompt);
                        query.EndDate = DatePrompt.Ask(Console, Resource.DateEndPrompt);
                        break;

                    case ListTransactionFilterDialogOptionEnum.Pendente:
                        query.PendingOnly = ConfirmPrompt.Ask(Console, Resource.Pending);
                        break;

                    case ListTransactionFilterDialogOptionEnum.Conta:
                        query.AccountIds = MultiSelectionPrompt.Ask(Console, Resource.Accounts, AccountDic);
                        break;

                    case ListTransactionFilterDialogOptionEnum.Categoria:
                        query.CategoryIds = MultiSelectionPrompt.Ask(Console, Resource.Categories, CategoriesDic);
                        break;

                    case ListTransactionFilterDialogOptionEnum.Clear:
                        return Task.FromResult(ListTransactionsQuery.Default());

                    case ListTransactionFilterDialogOptionEnum.Exit:
                        return Task.FromResult(query);
                }
            }
            while (true);
        }

        private void RenderFilterSummary(ListTransactionsQuery query)
        {
            var grid = new Grid();
            grid.AddColumn(new GridColumn().NoWrap());
            grid.AddColumn();

            string DateOrDash(DateTime? d) => d.HasValue ? d.Value.ToString(Resource.DateFormat) : Resource.Dash;
            string TextOrDash(string? s) => string.IsNullOrWhiteSpace(s) ? Resource.Dash : s;

            grid.AddRow(new Markup(Resource.Period.Color(Color.Grey)), new Markup($"{DateOrDash(query.StartDate)} {Resource.RangeConnector.Color(Color.Grey)} {DateOrDash(query.EndDate)}"));
            grid.AddRow(new Markup(Resource.Description.Color(Color.Grey)), new Markup(TextOrDash(query.Description)));
            grid.AddRow(new Markup(Resource.Pending.Color(Color.Grey)), new Markup(query.PendingOnly ? Resource.Pending.Color(Color.Yellow) : Resource.No));
            grid.AddRow(new Markup(Resource.Accounts.Color(Color.Grey)), new Markup(query.AccountIds is { Count: > 0 } ? query.AccountIds.Count.ToString() : Resource.Dash));
            grid.AddRow(new Markup(Resource.Categories.Color(Color.Grey)), new Markup(query.CategoryIds is { Count: > 0 } ? query.CategoryIds.Count.ToString() : Resource.Dash));

            var panel = new Panel(new Rows(grid))
            {
                Header = new PanelHeader(Resource.Filters, Justify.Center),
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0),
                Expand = true
            };

            Console.Write(panel);
        }

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingData, async _ =>
            {
                Accounts = await mediator.Send(new AccountListQuery());
                Categories = await mediator.Send(new CategoryListQuery());
            
                AccountDic = Accounts.ToDictionary(k => k.Id, v => v.Description);
                CategoriesDic = Categories.ToDictionary(k => k.Id, v => v.Description);
            });
        }
    }
}
