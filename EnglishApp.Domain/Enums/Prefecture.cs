﻿using System.ComponentModel.DataAnnotations;

namespace EnglishApp.Domain.Enums;

public enum Prefecture : byte
{
    [Display(Name = "未指定")]
    Unspecified = 0,

    [Display(Name = "北海道")]
    Hokkaido = 1,

    [Display(Name = "青森県")]
    Aomori = 2,

    [Display(Name = "岩手県")]
    Iwate = 3,

    [Display(Name = "宮城県")]
    Miyagi = 4,

    [Display(Name = "秋田県")]
    Akita = 5,

    [Display(Name = "山形県")]
    Yamagata = 6,

    [Display(Name = "福島県")]
    Fukushima = 7,

    [Display(Name = "茨城県")]
    Ibaraki = 8,

    [Display(Name = "栃木県")]
    Tochigi = 9,

    [Display(Name = "群馬県")]
    Gunma = 10,

    [Display(Name = "埼玉県")]
    Saitama = 11,

    [Display(Name = "千葉県")]
    Chiba = 12,

    [Display(Name = "東京都")]
    Tokyo = 13,

    [Display(Name = "神奈川県")]
    Kanagawa = 14,

    [Display(Name = "新潟県")]
    Niigata = 15,

    [Display(Name = "富山県")]
    Toyama = 16,

    [Display(Name = "石川県")]
    Ishikawa = 17,

    [Display(Name = "福井県")]
    Fukui = 18,

    [Display(Name = "山梨県")]
    Yamanashi = 19,

    [Display(Name = "長野県")]
    Nagano = 20,

    [Display(Name = "岐阜県")]
    Gifu = 21,

    [Display(Name = "静岡県")]
    Shizuoka = 22,

    [Display(Name = "愛知県")]
    Aichi = 23,

    [Display(Name = "三重県")]
    Mie = 24,

    [Display(Name = "滋賀県")]
    Shiga = 25,

    [Display(Name = "京都府")]
    Kyoto = 26,

    [Display(Name = "大阪府")]
    Osaka = 27,

    [Display(Name = "兵庫県")]
    Hyogo = 28,

    [Display(Name = "奈良県")]
    Nara = 29,

    [Display(Name = "和歌山県")]
    Wakayama = 30,

    [Display(Name = "鳥取県")]
    Tottori = 31,

    [Display(Name = "島根県")]
    Shimane = 32,

    [Display(Name = "岡山県")]
    Okayama = 33,

    [Display(Name = "広島県")]
    Hiroshima = 34,

    [Display(Name = "山口県")]
    Yamaguchi = 35,

    [Display(Name = "徳島県")]
    Tokushima = 36,

    [Display(Name = "香川県")]
    Kagawa = 37,

    [Display(Name = "愛媛県")]
    Ehime = 38,

    [Display(Name = "高知県")]
    Kochi = 39,

    [Display(Name = "福岡県")]
    Fukuoka = 40,

    [Display(Name = "佐賀県")]
    Saga = 41,

    [Display(Name = "長崎県")]
    Nagasaki = 42,

    [Display(Name = "熊本県")]
    Kumamoto = 43,

    [Display(Name = "大分県")]
    Oita = 44,

    [Display(Name = "宮崎県")]
    Miyazaki = 45,

    [Display(Name = "鹿児島県")]
    Kagoshima = 46,

    [Display(Name = "沖縄県")]
    Okinawa = 47
}
