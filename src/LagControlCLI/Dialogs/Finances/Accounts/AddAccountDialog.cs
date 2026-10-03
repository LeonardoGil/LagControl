using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Accounts;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Accounts
{
    internal class AddAccountDialog(IAnsiConsole console, IMediator mediator) : DialogAndReturnBase<object?, bool>(console), IAddAccountDialog
    {
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

        private AddAccountCommand Ask()
        {
            var descricao = TextPrompt.Ask(Console, Resource.Description);

            return new AddAccountCommand
            {
                Description = descricao,
                InitialBalance = 0
            };
        }
    }
}
