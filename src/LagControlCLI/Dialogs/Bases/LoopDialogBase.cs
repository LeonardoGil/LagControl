using LagControlCLI.Dialogs.Interfaces.Bases;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Bases;

internal abstract class LoopDialogBase(IAnsiConsole console, bool enableCancellationToken = false) : DialogBase(console, enableCancellationToken), ILoopDialogBase
{
    private bool _shouldExit;

    public override async Task Show()
    {
        Console.Clear();
        RenderHeader();
        Start();

        if (CancellationEnabled)
        {
            using var cts = new CancellationTokenSource();
            using (DialogCancellation.SetCurrent(cts))
            {
                CancellationToken = cts.Token;

                try
                {
                    await LoadAsync();

                    if (_shouldExit)
                        return;

                    while (!_shouldExit)
                    {
                        Console.Clear();
                        RenderHeader();

                        await ExecuteAsync();
                    }
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

            if (_shouldExit)
                return;

            while (!_shouldExit)
            {
                Console.Clear();
                RenderHeader();

                await ExecuteAsync();
            }
        }
    }

    private void Start() => _shouldExit = false;
    protected void Stop() => _shouldExit = true;
}
