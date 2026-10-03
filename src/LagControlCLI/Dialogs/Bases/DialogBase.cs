using LagControlCLI.Dialogs.Interfaces.Bases;
using LagControlCLI.Extensions;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Bases;

internal abstract class DialogBase : IDialogBase
{
    private readonly IAnsiConsole _console;
    private readonly FigletFont _titleFont;
    private readonly bool _enableCancellationToken;
    
    protected IAnsiConsole Console { get => _console; }
    protected bool CancellationEnabled { get => _enableCancellationToken; }
    protected CancellationToken? CancellationToken { get; set; } = null;

    public DialogBase(IAnsiConsole console, bool enableCancellation = false)
    {
        using var figleFontStream = new MemoryStream(Resource.FigletFont_3d);
        
        _console = console;
        _titleFont = FigletFont.Load(figleFontStream);
        _enableCancellationToken = enableCancellation;
    }

    public virtual async Task Show()
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
                    await ExecuteAsync();
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
            await ExecuteAsync();
        }
    }

    protected abstract Task ExecuteAsync();
    protected virtual Task LoadAsync() => Task.CompletedTask;

    protected void RenderHeader()
    {
        Console.Clear();


        var title = new FigletText(_titleFont, "LAG Control").Color(Color.DeepSkyBlue3).Centered();

        var version = GetType().Assembly.GetName().Version ?? new Version(1, 0);
        var info = new Markup($"[grey]Versão: [/] {version}  [grey]|[/] [grey]Hora: [/] {DateTime.Now:HH:mm:ss}").Centered();

        var body = new Rows(title, new Text($"{Environment.NewLine}{Environment.NewLine}"), info);
        var mainPanel = new Panel(body)
        {
            Border = BoxBorder.None,
            Padding = new Padding(1, 2, 1, 2)
        };

        Console.Write(mainPanel);
        Console.WriteLine();
    }
}