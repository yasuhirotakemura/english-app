using System.ComponentModel;

namespace EnglishApp.Domain.Enums;

public enum Gender : byte
{
    [Description("未指定")] Unspecified = 0,
    [Description("男性")] Male = 1,
    [Description("女性")] Female = 2,
    [Description("その他")] Other = 3
}
