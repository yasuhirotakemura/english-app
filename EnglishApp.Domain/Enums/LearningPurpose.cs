using System.ComponentModel;

namespace EnglishApp.Domain.Enums;

public enum LearningPurpose : byte
{
    [Description("その他の学習目的")] Else = 0,
    [Description("受験対策")] Exam = 1,
    [Description("日常会話")] Conversation = 2,
    [Description("ビジネス英語")] Business = 3,
    [Description("旅行")] Travel = 4,
    [Description("趣味")] Hobby = 5,
    [Description("資格試験（英検、TOEICなど）")] Qualification = 6,
    [Description("留学準備")] StudyAbroad = 7
}
