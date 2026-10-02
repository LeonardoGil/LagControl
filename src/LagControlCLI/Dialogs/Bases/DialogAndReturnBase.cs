using LagControlCLI.Dialogs.Interfaces.Bases;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Bases
{
    internal abstract class DialogAndReturnBase<TIn, TOut>(IAnsiConsole console) : DialogBase(console), IDialogAndReturnBase<TIn, TOut>
    {
        public virtual async Task<TOut> ShowAndReturn(TIn input)
        {
            Console.Clear();
            
            RenderHeader();

            await LoadAsync();

            return await ExecuteAndReturnAsync(input);
        }

        protected override Task ExecuteAsync() => throw new NotSupportedException();
        protected abstract Task<TOut> ExecuteAndReturnAsync(TIn input);
    }
}
