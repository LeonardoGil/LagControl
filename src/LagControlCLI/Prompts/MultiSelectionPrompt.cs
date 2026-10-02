using Spectre.Console;

namespace LagControlCLI.Prompts
{
    internal static class MultiSelectionPrompt
    {
        internal static MultiSelectionPrompt<T> GetSelectPrompt<T>(string title, Dictionary<T, string> options) where T : notnull
        {
            return new MultiSelectionPrompt<T>().Title(title)
                                           .AddChoices(options!.Keys)
                                           .UseConverter(e => options[e]);
        }

        internal static IList<T> Ask<T>(this IAnsiConsole console, string title, Dictionary<T, string> options) where T : notnull
        {
            var prompt = GetSelectPrompt(title, options);

            return console.Prompt(prompt);
        }
    }
}
