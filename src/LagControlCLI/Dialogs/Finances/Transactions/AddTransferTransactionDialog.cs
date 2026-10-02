using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Transactions;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class AddTransferTransactionDialog(IAnsiConsole console, IMediator mediator) : LoopDialogBase(console), IAddTransferTransactionDialog
    {
        protected IList<AccountListDto> Account { get; set; } = default!;

        protected override async Task ExecuteAsync()
        {
            var command = Ask();

            Console.WriteLine();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, AddAndContinueDialogOptions.Options);

            switch (action)
            {
                case AddAndContinueDialogOptionsEnum.Add:
                    await mediator.Send(command);
                    Stop();
                    break;

                case AddAndContinueDialogOptionsEnum.AddAndContinue:
                    await mediator.Send(command);
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
            });
        }

        private AddTransferTransactionCommand Ask()
        {
            var description = TextPrompt.Ask(Console, Resource.Description);
            var observation = TextPrompt.Ask(Console, Resource.NotesLabel, allowEmpty: true);

            var value = DecimalPrompt.Ask(Console, Resource.ValueColumn);
            var pending = ConfirmPrompt.Ask(Console, $"{Resource.Pending}?");

            var date = DatePrompt.Ask(Console, Resource.DateLabel, options: DateDialogOptions.Options);

            var accountDic = Account.ToDictionary(k => k, v => v.Description);
            var account = SelectionPrompt.Ask(Console, Resource.AccountColumn, accountDic);
            Console.MarkupLine($"{Resource.AccountColumn.Bold()} {account.Description}");

            var transferAccountDic = Account.Where(a => a.Id != account.Id).ToDictionary(k => k, v => v.Description);
            var transferAccount = SelectionPrompt.Ask(Console, Resource.TransferAccountLabel, transferAccountDic);
            Console.MarkupLine($"{Resource.TransferAccountLabel.Bold()} {transferAccount.Description}");

            return new AddTransferTransactionCommand()
            {
                Description = description,
                Notes = observation,
                Amount = value,
                Date = date,
                Pending = pending,
                AccountId = account.Id,
                TransferAccountId = transferAccount.Id
            };
        }
    }
}
