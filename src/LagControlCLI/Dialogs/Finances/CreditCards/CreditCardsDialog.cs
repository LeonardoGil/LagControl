using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagControlCLI.Extensions;
using LagFinanceApplication.Dtos.CreditCards;
using LagFinanceApplication.Queries.CreditCards;
using MediatR;
using Spectre.Console;
using static LagControlCLI.Options.CreditCardsDialogOptions;

namespace LagControlCLI.Dialogs.Finances.CreditCards
{
    internal class CreditCardsDialog(IAnsiConsole console, IMediator mediator, IAddCreditCardDialog addCreditCardDialog) : LoopDialogBase(console), ICreditCardsDialog
    {
        protected IList<CreditCardListDto> Cards { get; set; } = default!;

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.LoadingData, async _ =>
            {
                Cards = await mediator.Send(new CreditCardListQuery());
            });
        }

        protected override async Task ExecuteAsync()
        {
            RenderCards();

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, CreditCardsDialogOptions.Options);

            switch (action)
            {
                case CreditCardsDialogOptionEnum.AddCreditCard:
                    if (await addCreditCardDialog.ShowAndReturn(null))
                    {
                        await LoadAsync();
                    }
                    break;

                case CreditCardsDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }

        private void RenderCards()
        {
            if (Cards == null || !Cards.Any())
            {
                Console.WriteLine("Nenhum cartão encontrado.");
                return;
            }

            var table = new Table().Expand();
            table.AddColumn("Titular");
            table.AddColumn("Conta");
            table.AddColumn("Limite");
            table.AddColumn("Disponível");

            foreach (var card in Cards)
                table.AddRow(card.HolderName!, card.Account!, card.CreditLimit.ToString("C"), card.AvailableLimit.ToString("C"));

            Console.Write(table);
        }
    }
}
