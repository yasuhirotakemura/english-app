using System.ComponentModel;

namespace EnglishApp.Domain.Enums;

public enum LearningPurpose : byte
{
    [Description("受験対策")] Exam = 0,
    [Description("日常会話")] Conversation = 1,
    [Description("ビジネス英語")] Business = 2,
    [Description("旅行")] Travel = 3,
    [Description("趣味")] Hobby = 4,
    [Description("資格試験（英検、TOEICなど）")] Qualification = 5,
    [Description("留学準備")] StudyAbroad = 6,
    [Description("その他の学習目的")] Else = 7,
}
