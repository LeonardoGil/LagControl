using LagControlCLI.Extensions;
using Spectre.Console;
using System.Globalization;

namespace LagControlCLI.Prompts
{
    internal static class DecimalPrompt
    {
        internal static TextPrompt<string> GetTextPrompt(string message, CultureInfo? culture = null, Style? promptStyle = null, bool allowEmpty = false, decimal? min = null, decimal? max = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            promptStyle ??= new Style(Color.Yellow);

            var prompt = new TextPrompt<string>(message).PromptStyle(promptStyle);

            if (allowEmpty)
                prompt.AllowEmpty();

            prompt.Validate(input =>
            {
                if (string.IsNullOrWhiteSpace(input))
                    return allowEmpty ? ValidationResult.Success() : ValidationResult.Error("[red]Valor obrigatório.[/]");

                if (!decimal.TryParse(input, NumberStyles.Number, culture, out var value))
                    return ValidationResult.Error("[red]Número decimal inválido.[/]");

                if (min.HasValue && value < min.Value)
                    return ValidationResult.Error($"[red]Valor deve ser >= {min.Value.ToString(culture)}.[/]");

                if (max.HasValue && value > max.Value)
                    return ValidationResult.Error($"[red]Valor deve ser <= {max.Value.ToString(culture)}.[/]");

                return ValidationResult.Success();
            });

            return prompt;
        }

        internal static decimal Ask(this IAnsiConsole console, string message, CultureInfo? culture = null, Style? promptStyle = null, bool allowEmpty = false, decimal? min = null, decimal? max = null, CancellationToken? cancellationToken = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            promptStyle ??= new Style(Color.Yellow);

            var messageFormated = $"{message.Bold()}: ";

            var prompt = GetTextPrompt(messageFormated, culture, promptStyle, allowEmpty, min, max);

            cancellationToken?.ThrowIfCancellationRequested();

            var result = console.Prompt(prompt);

            cancellationToken?.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(result) && allowEmpty)
            {
                return decimal.Zero;
            }
            else
            {
                return decimal.Parse(result, NumberStyles.Number);
            }
        }
    }
}
