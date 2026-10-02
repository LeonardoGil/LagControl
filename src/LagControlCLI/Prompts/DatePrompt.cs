using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Resources;
using Spectre.Console;
using System.Globalization;

namespace LagControlCLI.Prompts
{
    internal static class DatePrompt
    {
        internal static TextPrompt<string> GetTextPrompt(string message, string format, CultureInfo culture, Style promptStyle)
        {
            return new TextPrompt<string>(message).PromptStyle(promptStyle).Validate(input =>
            {
                var sucess = DateTime.TryParseExact(input, format, culture, DateTimeStyles.None, out _);

                return sucess ? ValidationResult.Success() : 
                                ValidationResult.Error(string.Format(Resource.DateInvalidFormat, format).Color(Color.Red));
            });
        }

        internal static DateTime Ask(this IAnsiConsole console, string? message, string? format = null, CultureInfo? culture = null, Style? promptStyle = null, Dictionary<DateDialogOptions.DateDialogOptionsEnum, string>? options = null, CancellationToken? cancellationToken = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            promptStyle ??= new Style(Color.Yellow);

            format ??= Resource.DateFormat;

            var messageFormated = string.IsNullOrEmpty(message) ? string.Empty : $"{message.Bold()}: ";
            var result = default(DateTime);

            cancellationToken?.ThrowIfCancellationRequested();

            if (options is not null)
            {
                var date = SelectionPrompt.Ask(console, message, options, cancellationToken: cancellationToken);

                if (date != DateDialogOptions.DateDialogOptionsEnum.Other)
                {
                    result = date.Convert();
                    console.MarkupLine($"{messageFormated} {result.ToString(format)}");
                }
            }

            if (result == default)
            {
                var textPrompt = GetTextPrompt(messageFormated, format, culture, promptStyle);
                var dateString = console.Prompt(textPrompt);

                result = DateTime.ParseExact(dateString, format, culture);
            }

            cancellationToken?.ThrowIfCancellationRequested();

            return result;
        }
    }

}
