using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EnglishApp.Domain.Helpers;

public static class EnumHelper
{
    public static string GetDisplayName(Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        DisplayAttribute? attribute = field?.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? value.ToString();
    }

    private static string GetDescription<T>(T value) where T : Enum
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        DescriptionAttribute? attribute = field?.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }

    public static Dictionary<byte, string> ToDictionary<T>() where T : Enum
    {
        Dictionary<byte, string> dict = new();

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            dict.Add(Convert.ToByte(value), GetDescription(value));
        }

        return dict;
    }
}