using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using Spectre.Console;
using static LagControlCLI.Options.ReportsDialogOptions;

namespace LagControlCLI.Dialogs.Finances.Reports
{
    internal class ReportsDialog(IAnsiConsole console, IStatementReportDialog statementReportDialog) : LoopDialogBase(console), IReportsDialog
    {
        protected override Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync()
        {
            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, ReportsDialogOptions.Options);

            switch (action)
            {
                case ReportsDialogOptionEnum.Statement:
                    await statementReportDialog.Show();
                    break;

                case ReportsDialogOptionEnum.Back:
                    Stop();
                    break;
            }
        }
    }
}
