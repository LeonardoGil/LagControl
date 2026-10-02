using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Categories;
using LagFinanceDomain.Enums;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.AddAndContinueDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Categories
{
    internal class AddCategoryDialog(IAnsiConsole console, IMediator mediator) : DialogBase(console), IAddCategoryDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected async override Task ExecuteAsync()
        {
            do
            {
                var adicionarCategoriaCommand = Ask();

                Console.WriteLine();

                var action = SelectionPrompt.Ask(Console, string.Empty, AddAndContinueDialogOptions.Options);

                switch (action)
                {
                    case AddAndContinueDialogOptionsEnum.Add:
                        await mediator.Send(adicionarCategoriaCommand);
                        break;

                    case AddAndContinueDialogOptionsEnum.AddAndContinue:
                        await mediator.Send(adicionarCategoriaCommand);
                        continue;
                }

                return;

            } while (true);
        }

        private AddCategoryCommand Ask()
        {
            var description = TextPrompt.Ask(Console, Resource.DescriptionLabel);

            var typeDic = new CategoryTypeEnum[] { CategoryTypeEnum.Income, CategoryTypeEnum.Expense }.ToDictionary(k => k, v => Enum.GetName(v));
            var categoryType = SelectionPrompt.Ask(Console, Resource.TypeLabel, typeDic!);

            Console.MarkupLine($"{Resource.TypeLabel.Bold()}: {Enum.GetName(categoryType)}");

            return new AddCategoryCommand
            {
                Description = description,
                Type = categoryType
            };
        }
    }
}
