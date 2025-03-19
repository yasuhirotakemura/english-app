using System.ComponentModel.DataAnnotations;

namespace EnglishApp.Domain.Enums;


public enum Gender : byte
{
    [Display(Name = "男性")]
    Male = 0,

    [Display(Name = "女性")]
    Female = 1,

    [Display(Name = "その他")]
    Other = 2
}