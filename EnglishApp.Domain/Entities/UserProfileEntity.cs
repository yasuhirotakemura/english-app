namespace EnglishApp.Domain.Entities;

public sealed class UserProfileEntity(int userId,
                                      string nickName,
                                      int genderId,
                                      int gradeId,
                                      int learningPurposeId,
                                      int prefectureId,
                                      string grade,
                                      string learningPurpose,
                                      string prefecture,
                                      DateTime? birthDate,
                                      string? profileText,
                                      bool isDeleted,
                                      DateTime accountCreatedAt,
                                      DateTime profileUpdatedAt,
                                      DateTime lastLoginAt,
                                      string iconUri)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public int Gender { get; } = genderId;
    public int GradeId { get; } = gradeId;
    public int LearningPurposeId { get; } = learningPurposeId;
    public int PrefectureId { get; } = prefectureId;
    public string Grade { get; } = grade;
    public string LearningPurpose { get; } = learningPurpose;
    public string Prefecture { get; } = prefecture;
    public DateTime? BirthDate { get; } = birthDate;
    public string? ProfileText { get; } = profileText;
    public bool IsDeleted { get; } = isDeleted;
    public DateTime AccountCreatedAt { get; } = accountCreatedAt;
    public DateTime ProfileUpdatedAt { get; } = profileUpdatedAt;
    public DateTime LastLoginAt { get; } = lastLoginAt;
    public string IconUri { get; } = iconUri;

    public override string ToString()
    {
        return "UserId: " + this.UserId +
               ", NickName: " + this.NickName +
               ", Gender: " + this.Gender +
               ", GradeId: " + this.GradeId + " (" + this.Grade + ")" +
               ", LearningPurposeId: " + this.LearningPurposeId + " (" + this.LearningPurpose + ")" +
               ", PrefectureId: " + this.PrefectureId + " (" + this.Prefecture + ")" +
               ", BirthDate: " + (this.BirthDate.HasValue ? this.BirthDate.Value.ToString("yyyy-MM-dd") : "N/A") +
               ", ProfileText: " + (String.IsNullOrWhiteSpace(this.ProfileText) ? "N/A" : this.ProfileText) +
               ", IsDeleted: " + this.IsDeleted +
               ", CreatedAt: " + this.AccountCreatedAt.ToString("yyyy-MM-dd HH:mm:ss") +
               ", UpdatedAt: " + this.ProfileUpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") +
               ", LastLoginAt: " + this.LastLoginAt.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
