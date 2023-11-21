using LagControlCLI.Arguments;

namespace LagControlCLI.Utils.Extensions
{
    public static class ArgumentExtensions
    {
        public static string Build(this string arg) => string.Concat("-", arg);

        public static bool CheckMandatoryArguments<TEnum>(this string[] args, TEnum[] mandatoryArray) 
            where TEnum : struct
        {
            return mandatoryArray.All(mandatory => args.Contains(mandatory.ToString().Build()));
        }

        public static bool IsArgument<TEnum>(this string arg) where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(arg) || !arg.StartsWith("-"))
                return false;

            var sucess = Enum.TryParse<TEnum>(arg, out _);

            return sucess;
        }

        public static bool IsArgument<TEnum>(this string arg, out TEnum argEnum) where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(arg) || !arg.StartsWith("-"))
            {
                argEnum = default;
                return false;
            }

            var argEnumText = arg.TrimStart(char.Parse("-"));

            return Enum.TryParse(argEnumText, out argEnum);
        }

        public static decimal EnterADecimal(string? info = null)
        {
            decimal enter;
            bool sucess;

            do
            {
                Console.WriteLine(info ?? "Enter a decimal: ");
                var read = Console.ReadLine();

                sucess = !decimal.TryParse(read, out enter);
            }
            while (sucess);

            return enter;
        }

        public static string EnterAText(string? info = null)
        {
            string? enter;
            do
            {
                Console.WriteLine(info ?? "Enter a text: ");
                enter = Console.ReadLine();
            } 
            while (string.IsNullOrEmpty(enter));

            return enter;
        }

        public static DateTime EnterADateTime(string? info = null)
        {
            DateTime enter;
            bool sucess;

            do
            {
                Console.WriteLine(info ?? "Enter a DateTime: ");
                var read = Console.ReadLine();

                sucess = !DateTime.TryParse(read, out enter);
            }
            while (sucess);

            return enter;
        }

        public static string? GetValueFromArgument<TEnum>(this string[] args, int index)
            where TEnum : struct
        {
            var nextIndexArg = index + 1;
            var existsNextArg = nextIndexArg < args.Length;
            
            if (existsNextArg && !IsArgument<TEnum>(args[nextIndexArg]))
            {
                return args[nextIndexArg];
            }
            else
            {
                return null;
            }
        }

        public static string ProcessStringArgument<TEnum>(this string[] args, ref int index, string text = null)
            where TEnum : struct
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            if (value is null)
            {
                value = EnterAText(text);
            }
            else
            {
                index++;
            }

            return value;
        }

        public static decimal ProcessDecimalArgument<TEnum>(this string[] args, ref int index, string text = null)
            where TEnum : struct
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            var sucess = decimal.TryParse(value, out decimal result);

            if (sucess)
            {
                index++;
            }
            else
            {
                result = EnterADecimal(text);
            }

            return result;
        }

        public static DateTime ProcessDateTimeArgument<TEnum>(this string[] args, ref int index, string text = null)
        {
            var value = args.GetValueFromArgument<FinanceAddArgumentsEnum>(index);

            var sucess = DateTime.TryParse(value, out DateTime result);

            if (sucess)
            {
                index++;
            }
            else
            {
                result = EnterADateTime(text);
            }

            return result;
        }
    }
}