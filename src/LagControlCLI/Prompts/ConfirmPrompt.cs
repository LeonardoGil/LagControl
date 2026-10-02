using LagControlCLI.Extensions;
using Spectre.Console;

namespace LagControlCLI.Prompts
{
    internal static class ConfirmPrompt
    {
        internal static ConfirmationPrompt GetTextPrompt(string title, bool defaultValue = true)
        {
            return new ConfirmationPrompt(title)
            {
                DefaultValue = defaultValue
            };
        }

        internal static bool Ask(this IAnsiConsole console, string message, bool defaultValue = true, CancellationToken? cancellationToken = null)
        {
            var prompt = GetTextPrompt(message.Bold(), defaultValue);

            cancellationToken?.ThrowIfCancellationRequested();

            var result = console.Prompt(prompt);

            cancellationToken?.ThrowIfCancellationRequested();

            return result;
        }
    }
}
