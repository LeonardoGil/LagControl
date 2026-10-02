using LagControlCLI.Extensions;
using Spectre.Console;

namespace LagControlCLI.Prompts
{
    internal static class SelectionPrompt
    {
        internal static SelectionPrompt<T> GetSelectPrompt<T>(string? message, Dictionary<T, string> options) where T : notnull
        {
            return new SelectionPrompt<T>().Title(message)
                                           .AddChoices(options!.Keys)
                                           .UseConverter(e => options[e]);
        }

        internal static T Ask<T>(this IAnsiConsole console, string? message, Dictionary<T, string> options, CancellationToken? cancellationToken = null) where T : notnull
        {
            if (!string.IsNullOrEmpty(message))
            {
                message = $"{message.Bold()}: ";
            }

            var prompt = GetSelectPrompt(message, options);

            cancellationToken?.ThrowIfCancellationRequested();

            var result = console.Prompt(prompt);

            cancellationToken?.ThrowIfCancellationRequested();

            return result;
        }
    }
}
