using System.ComponentModel.DataAnnotations;

namespace EnglishApp.Domain.Enums;


public enum Grade : byte
{
    [Display(Name = "未指定")]
    Unspecified = 0,

    [Display(Name = "中学1年")]
    JuniorHigh1 = 1,

    [Display(Name = "中学2年")]
    JuniorHigh2 = 2,

    [Display(Name = "中学3年")]
    JuniorHigh3 = 3,

    [Display(Name = "高校1年")]
    HighSchool1 = 4,

    [Display(Name = "高校2年")]
    HighSchool2 = 5,

    [Display(Name = "高校3年")]
    HighSchool3 = 6,

    [Display(Name = "大学生以上")]
    Adult = 7
}