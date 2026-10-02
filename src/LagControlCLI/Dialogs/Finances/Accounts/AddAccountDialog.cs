using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Accounts;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Accounts
{
    internal class AddAccountDialog(IAnsiConsole console, IMediator mediator) : DialogBase(console), IAddAccountDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected async override Task ExecuteAsync()
        {
            var command = Ask();

            Console.WriteLine();

            await mediator.Send(command);

            Console.Prompt(new TextPrompt<string>(Resource.PressEnterToReturn.Color(Color.Grey)).AllowEmpty());
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
