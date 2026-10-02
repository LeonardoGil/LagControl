using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using Spectre.Console;
using static LagControlCLI.Options.MainFinanceDialogOptions;

namespace LagControlCLI.Dialogs.Finances
{
    internal class MainFinanceDialog(IAnsiConsole console, 
                                     ITransactionDialog transactionDialog,
                                     IAccountsDialog accountsDialog,
                                     ICategoryDialog categoryDialog,
                                     IReportsDialog reportsDialog) : LoopDialogBase(console), IMainFinanceDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync()
        {
            var result = SelectionPrompt.Ask(Console, Resource.SelectAction, MainFinanceDialogOptions.Options);

            switch (result)
            {
                case MainFinanceDialogOptionEnum.Transaction:
                    await transactionDialog.Show();
                    break;
                
                case MainFinanceDialogOptionEnum.Accounts:
                    await accountsDialog.Show();
                    break;

                case MainFinanceDialogOptionEnum.Reports:
                    await reportsDialog.Show();
                    break;

                case MainFinanceDialogOptionEnum.Categories:
                    await categoryDialog.Show();
                    break;

                case MainFinanceDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }
    }
}
