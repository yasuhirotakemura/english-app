using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EnglishApp.Domain.Helpers;

public static class EnumHelper
{
    private static string GetDisplayName(Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        DisplayAttribute? attribute = field?.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? value.ToString();
    }

    public static Dictionary<int, string> ToDictionary<T>() where T : Enum
    {
        Dictionary<int, string> dict = [];

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            dict.Add(Convert.ToByte(value), GetDisplayName(value));
        }

        return dict;
    }
}