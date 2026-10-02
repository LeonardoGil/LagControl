using LagControlCLI.Extensions;
using LagControlCLI.Resources;
using Spectre.Console;
using System;

namespace LagControlCLI.Prompts
{
    internal static class TextPrompt
    {
        internal static TextPrompt<string> GetTextPrompt(string message, Style? promptStyle = null, bool allowEmpty = false)
        {
            promptStyle ??= new Style(Color.Yellow);

            var prompt = new TextPrompt<string>(message).PromptStyle(promptStyle);

            if (allowEmpty)
                prompt.AllowEmpty();

            return prompt;
        }

        internal static string Ask(this IAnsiConsole console, string message, Style? promptStyle = null, bool allowEmpty = false, CancellationToken? cancellationToken = null)
        {
            var messageFormated = $"{message.Bold()}: ";

            cancellationToken?.ThrowIfCancellationRequested();

            var prompt = GetTextPrompt(messageFormated, promptStyle, allowEmpty);

            cancellationToken?.ThrowIfCancellationRequested();

            var result = console.Prompt(prompt);

            cancellationToken?.ThrowIfCancellationRequested();

            return result;
        }

        internal static void AskPressEnterToReturn(this IAnsiConsole console) => console.Prompt(new TextPrompt<string>(Resource.PressEnterToReturn.Color(Color.Grey)).AllowEmpty());
    }
}
