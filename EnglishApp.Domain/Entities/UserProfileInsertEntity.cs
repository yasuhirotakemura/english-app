namespace EnglishApp.Domain.Entities;

public sealed class UserProfileInsertEntity(int userId,
                                           string nickName,
                                           byte gender,
                                           int gradeId,
                                           int learningPurposeId,
                                           int prefectureId,
                                           DateTime? birthDate,
                                           string? profileText)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public byte Gender { get; } = gender;
    public int GradeId { get; } = gradeId;
    public int LearningPurposeId { get; } = learningPurposeId;
    public int PrefectureId { get; } = prefectureId;
    public DateTime? BirthDate { get; } = birthDate;
    public string? ProfileText { get; } = profileText;
}