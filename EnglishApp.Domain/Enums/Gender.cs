using System.ComponentModel;

namespace EnglishApp.Domain.Enums;

public enum Gender : byte
{
    [Description("男性")] Male = 0,
    [Description("女性")] Female = 1,
    [Description("その他")] Other = 2
}
