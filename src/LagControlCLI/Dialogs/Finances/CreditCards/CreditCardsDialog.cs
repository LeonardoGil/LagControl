using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using Spectre.Console;
using static LagControlCLI.Options.CreditCardsDialogOptions;

namespace LagControlCLI.Dialogs.Finances.CreditCards
{
    internal class CreditCardsDialog(IAnsiConsole console, IAddCreditCardDialog addCreditCardDialog) : LoopDialogBase(console), ICreditCardsDialog
    {
        protected override async Task ExecuteAsync()
        {
            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, CreditCardsDialogOptions.Options);

            switch (action)
            {
                case CreditCardsDialogOptionEnum.AddCreditCard:
                    
                    if (await addCreditCardDialog.ShowAndReturn(null))
                        await LoadAsync();
                    
                    break;

                case CreditCardsDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }
    }
}
