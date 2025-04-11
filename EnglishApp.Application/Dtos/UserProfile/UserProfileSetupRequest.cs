namespace EnglishApp.Application.Dtos.UserProfile;

public sealed class UserProfileSetupRequest(int userId,
                                            string nickName,
                                            int gender,
                                            int gradeId,
                                            int learningPurposeId,
                                            int prefectureId,
                                            DateTime? birthDate,
                                            string? profileText,
                                            string iconUri)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public int Gender { get; } = gender;
    public int GradeId { get; } = gradeId;
    public int LearningPurposeId { get; } = learningPurposeId;
    public int PrefectureId { get; } = prefectureId;
    public DateTime? BirthDate { get; } = birthDate;
    public string? ProfileText { get; } = profileText;
    public string IconUri { get; } = iconUri;
}