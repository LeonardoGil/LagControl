namespace LagControlCLI.Utils.Extensions
{
    public static class ArgumentExtensions
    {
        public static string Build(this string arg) => string.Concat("-", arg);

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
            bool sucess = true;

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

        public static string? GetValueFromArgument<TEnum>(this string[] args, int index)
            where TEnum : struct
        {
            var nextIndexArg = index + 1;
            var existsNextArg = args.Length < nextIndexArg;
            
            if (existsNextArg && !IsArgument<TEnum>(args[nextIndexArg]))
            {
                return args[nextIndexArg];
            }
            else
            {
                return null;
            }
        }
    }
}
