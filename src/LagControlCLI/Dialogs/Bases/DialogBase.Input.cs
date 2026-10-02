using LagControlCLI.Dialogs.Interfaces.Bases;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Bases
{
    internal abstract class DialogBase<TInput>(IAnsiConsole console, bool enableCancellation = false) : DialogBase(console, enableCancellation), IDialogBase<TInput> where TInput : notnull
    {
        public virtual async Task Show(TInput input)
        {
            Console.Clear();
            RenderHeader();

            if (CancellationEnabled)
            {
                using var cts = new CancellationTokenSource();
                using (DialogCancellation.SetCurrent(cts))
                {
                    CancellationToken = cts.Token;

                    try
                    {
                        await LoadAsync();
                        await ExecuteAsync(input);
                    }
                    catch (OperationCanceledException)
                    {
                        Console.MarkupLine("Operação cancelada".Color(Color.Yellow));
                        Console.AskPressEnterToReturn();
                        return;
                    }
                }
            }
            else
            {
                await LoadAsync();
                await ExecuteAsync(input);
            }
        }

        protected abstract Task ExecuteAsync(TInput input);
        protected override Task ExecuteAsync() => Task.CompletedTask;
    }

}
