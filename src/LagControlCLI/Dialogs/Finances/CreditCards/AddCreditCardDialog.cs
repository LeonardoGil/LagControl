using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.CreditCards;
using LagFinanceApplication.Dtos.Accounts;
using LagFinanceApplication.Queries.Accounts;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.CreditCards
{
    internal class AddCreditCardDialog(IAnsiConsole console, IMediator mediator) : DialogAndReturnBase<object?, bool>(console), IAddCreditCardDialog
    {
        protected IList<AccountListDto> Accounts { get; set; } = default!;

        protected async override Task<bool> ExecuteAndReturnAsync(object? input)
        {
            var command = Ask();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, AddAndContinueDialogOptions.Options1);

            switch (action)
            {
                case AddAndContinueDialogOptionsEnum.Add:
                    await mediator.Send(command);
                    return true;
            }

            return false;
        }

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingData, async _ =>
            {
                Accounts = await mediator.Send(new AccountListQuery());
            });
        }

        private CreateCreditCardCommand Ask()
        {
            var holder = TextPrompt.Ask(Console, Resource.HolderName);
            var creditLimit = DecimalPrompt.Ask(Console, Resource.CreditLimit);

            var closingDay = (int)DecimalPrompt.Ask(Console, Resource.ClosingDay, min: 1, max: 28);
            var dueDay = (int)DecimalPrompt.Ask(Console, Resource.DueDay, min: 1, max: 28);

            var accountDic = Accounts.ToDictionary(k => k, v => v.Description);
            var account = SelectionPrompt.Ask(Console, Resource.AccountColumn, accountDic);

            return new CreateCreditCardCommand
            {
                HolderName = holder,
                CreditLimit = creditLimit,
                ClosingDay = closingDay,
                DueDay = dueDay,
                AccountId = account.Id
            };
        }
    }
}
