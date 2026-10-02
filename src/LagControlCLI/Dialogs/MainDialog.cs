using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using Spectre.Console;
using static LagControlCLI.Options.MainDialogOptions;

namespace LagControlCLI.Dialogs
{
    internal class MainDialog(IAnsiConsole console, IMainFinanceDialog mainFinanceDialog) : LoopDialogBase(console), IMainDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync()
        {
            var result = SelectionPrompt.Ask(Console, $"[yellow]{Resource.SelectModule}[/]", MainDialogOptions.Options);

            switch (result)
            {
                case MainDialogOptionsEnum.Finance:
                    await mainFinanceDialog.Show();
                    break;

                case MainDialogOptionsEnum.Exit:
                    Stop();
                    break;
            }
        }
    }
}