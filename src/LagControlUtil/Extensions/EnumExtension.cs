using System.ComponentModel;
using System.Reflection;

namespace LagControlUtil.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field is null)
                return string.Empty;

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            
            return attribute?.Description ?? string.Empty;
        }

        public static IEnumerable<string> GetAllDescriptions<T>() where T : Enum
        {
            var type = typeof(T);

            foreach (var value in Enum.GetValues(type))
            {
                var field = type.GetField(value.ToString()!);

                if (field is null)
                    continue;

                var attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute is null)
                    continue;

                yield return attribute.Description;
            }
        }

        public static T FromDescription<T>(this string description) where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute is not null && attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (T)field.GetValue(null)!;

                if (field.Name.Equals(description, StringComparison.OrdinalIgnoreCase))
                    return (T)Enum.Parse(typeof(T), field.Name, ignoreCase: true);
            }

            throw new ArgumentOutOfRangeException(nameof(description), $"Value '{description}' is not valid for enum {typeof(T).Name}");
        }
    }
}
