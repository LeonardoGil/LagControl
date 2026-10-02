using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Transactions;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Dtos.Categories;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceApplication.Queries.Categories;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class AddTransactionDialog(IAnsiConsole console, IMediator mediator) : LoopDialogBase(console, enableCancellationToken: true), IAddTransactionDialog
    {
        protected IList<AccountListDto> Account { get; set; } = default!;
        protected IList<CategoryListDto> Categories { get; set; } = default!;

        protected override async Task ExecuteAsync()
        {
            var adicionarMovimentacaoCommand = Ask();
            
            Console.WriteLine();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, AddAndContinueDialogOptions.Options);

            switch (action)
            {
                case AddAndContinueDialogOptionsEnum.Add:
                    await mediator.Send(adicionarMovimentacaoCommand);
                    Stop();
                    break;

                case AddAndContinueDialogOptionsEnum.AddAndContinue:
                    await mediator.Send(adicionarMovimentacaoCommand);
                    break;

                case AddAndContinueDialogOptionsEnum.Cancel:
                    Stop();
                    break;
            }

        }
        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingData, async _ =>
            {
                Account = await mediator.Send(new AccountListQuery());
                Categories = await mediator.Send(new CategoryListQuery());
            });
        }

        private AddTransactionCommand Ask()
        {

            var description = TextPrompt.Ask(Console, Resource.Description, cancellationToken: CancellationToken);
            var observation = TextPrompt.Ask(Console, Resource.NotesLabel, allowEmpty: true, cancellationToken: CancellationToken);
            var value = DecimalPrompt.Ask(Console, Resource.ValueColumn, cancellationToken: CancellationToken);
            
            var pending = ConfirmPrompt.Ask(Console, $"{Resource.Pending}?", defaultValue: false, cancellationToken: CancellationToken);
            var date = DatePrompt.Ask(Console, Resource.DateLabel, options: DateDialogOptions.Options);
            
            var accountDic = Account.ToDictionary(k => k, v => v.Description);
            var account = SelectionPrompt.Ask(Console, Resource.AccountColumn, accountDic, cancellationToken: CancellationToken);
            Console.MarkupLine($"{Resource.AccountColumn.Bold()} {account.Description}");

            var typeCategoryDic = new CategoryTypeEnum[] { CategoryTypeEnum.Expense, CategoryTypeEnum.Income }.ToDictionary(k => k, v => Enum.GetName(v));
            var typeCategory = SelectionPrompt.Ask(Console, Resource.TypeLabel, typeCategoryDic!, cancellationToken: CancellationToken);
            Console.MarkupLine($"{Resource.TypeLabel.Bold()} {Enum.GetName(typeCategory)}");
            
            var categoryDic = Categories.Where(x => x.Type == typeCategory).ToDictionary(k => k, v => v.Description);
            var category = SelectionPrompt.Ask(Console, Resource.CategoryColumn, categoryDic, cancellationToken: CancellationToken);
            Console.MarkupLine($"{Resource.CategoryColumn.Bold()} {category.Description}");
            
            return new AddTransactionCommand()
            {
                Description = description,
                Notes = observation,

                Type = (TransactionTypeEnum)typeCategory,
                Amount = value,
                Date = date,
                Pending = pending,

                CategoryId = category.Id,
                AccountId = account.Id
            };
        }
    }
}