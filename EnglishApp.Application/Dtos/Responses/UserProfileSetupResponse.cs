using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserProfileSetupResponse(string message,
                                             int userId,
                                             string nickName,
                                             byte gender,
                                             int gradeId,
                                             int learningPurposeId,
                                             int prefectureId,
                                             DateTime? birthDate,
                                             string? profileText,
                                             bool isDeleted,
                                             DateTime createdAt,
                                             DateTime updatedAt) : ResponseBase(message)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public byte Gender { get; } = gender;
    public int GradeId { get; } = gradeId;
    public int LearningPurposeId { get; } = learningPurposeId;
    public int PrefectureId { get; } = prefectureId;
    public DateTime? BirthDate { get; } = birthDate;
    public string? ProfileText { get; } = profileText;
    public bool IsDeleted { get; } = isDeleted;
    public DateTime CreatedAt { get; } = createdAt;
    public DateTime UpdatedAt { get; } = updatedAt;
}
