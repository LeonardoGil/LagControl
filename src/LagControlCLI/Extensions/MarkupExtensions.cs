using Spectre.Console;

namespace LagControlCLI.Extensions
{
    internal static class MarkupExtensions
    {
        internal static string Bold(this string input) => string.Concat("[bold]", input, "[/]");

        internal static string Color(this string input, Color color) => Color(input, color.ToString());
        internal static string Color(this string input, string color) => string.Concat($"[{color}]", input, "[/]");
    }
}
