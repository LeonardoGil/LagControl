using Spectre.Console;

namespace LagControlCLI.Extensions
{
    internal static class StatusExtensions
    {
        internal static async Task LoadingAsync(this IAnsiConsole console, string message, Func<StatusContext, Task> action)
        {
            await console.Status().Spinner(Spinner.Known.Dots).SpinnerStyle(Style.Parse("deepskyblue3")).StartAsync(message, action);
        }
    }
}
