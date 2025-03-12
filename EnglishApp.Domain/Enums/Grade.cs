using System.ComponentModel;

namespace EnglishApp.Domain.Enums;

public enum Grade : byte
{
    [Description("未指定")] Unspecified = 0,
    [Description("中学1年")] JuniorHigh1 = 7,
    [Description("中学2年")] JuniorHigh2 = 8,
    [Description("中学3年")] JuniorHigh3 = 9,
    [Description("高校1年")] HighSchool1 = 10,
    [Description("高校2年")] HighSchool2 = 11,
    [Description("高校3年")] HighSchool3 = 12,
    [Description("大学生")] University = 20,
    [Description("社会人")] Adult = 30
}
