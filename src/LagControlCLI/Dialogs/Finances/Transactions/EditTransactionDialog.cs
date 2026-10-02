using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Transactions;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Dtos.Categories;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Accounts;
using LagFinanceApplication.Queries.Categories;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class EditTransactionDialog(IAnsiConsole console, IMediator mediator) : DialogBase<TransactionGridDto>(console, enableCancellation: true), IEditTransactionDialog
    {
        protected IList<AccountListDto> Account { get; set; } = default!;
        protected IList<CategoryListDto> Categories { get; set; } = default!;

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingData, async _ =>
            {
                Account = await mediator.Send(new AccountListQuery());
                Categories = await mediator.Send(new CategoryListQuery());
            });
        }

        protected override async Task ExecuteAsync(TransactionGridDto input)
        {
            var command = EditTransaction(input);

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, AddAndContinueDialogOptions.Options1);

            switch (action)
            {
                case AddAndContinueDialogOptionsEnum.Add:
                    await mediator.Send(command);
                    break;

                case AddAndContinueDialogOptionsEnum.Cancel:
                    Console.MarkupLine("Operação Cancelada".Color(Color.Yellow));
                    break;
            }
        }
        
        private EditTransactionCommand EditTransaction(TransactionGridDto input)
        {
            var command = new EditTransactionCommand
            {
                Id = input.Id
            };

            if (ConfirmAsk(Resource.Description))
            {
                command.Description = TextPrompt.Ask(Console, Resource.Description, cancellationToken: CancellationToken);
            }

            if (ConfirmAsk(Resource.NotesLabel))
            {
                command.Notes = TextPrompt.Ask(Console, Resource.NotesLabel, allowEmpty: true, cancellationToken: CancellationToken);
            }

            if (ConfirmAsk(Resource.ValueLabel))
            {
                command.Amount = DecimalPrompt.Ask(Console, Resource.ValueColumn, min: 0, cancellationToken: CancellationToken);
            }

            if (ConfirmAsk(Resource.DateLabel))
            {
                command.Date = DatePrompt.Ask(Console, Resource.DateLabel, cancellationToken: CancellationToken);
            }

            var pending = ConfirmPrompt.Ask(Console, Resource.Pending + "?", input.Pending, cancellationToken: CancellationToken);

            if (ConfirmAsk(Resource.AccountLabel))
            {
                var accountDic = Account.ToDictionary(k => k, v => v.Description);

                command.AccountId = SelectionPrompt.Ask(Console, Resource.AccountColumn, accountDic, cancellationToken: CancellationToken).Id;
            }

            if (ConfirmAsk(Resource.CategoryLabel))
            {
                var categoryDic = Categories.Where(x => x.Type == (CategoryTypeEnum)input.Type).ToDictionary(k => k, v => v.Description);

                command.CategoryId = SelectionPrompt.Ask(Console, Resource.CategoryColumn, categoryDic, cancellationToken: CancellationToken).Id;
            }

            return command;
        }

        private bool ConfirmAsk(string property) => ConfirmPrompt.Ask(Console, $"Deseja alterar {property}?", cancellationToken: CancellationToken);
    }
}
