namespace EnglishApp.Application.Dtos;

public sealed class UserDetailRequest(int userId,
                                      string nickName,
                                      short genderId,
                                      int gradeId,
                                      int learningPurposeId,
                                      int prefectureId)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public short GenderId { get; } = genderId;
    public int GradeId { get; } = gradeId;
    public int LearningPurposeId { get; } = learningPurposeId;
    public int PrefectureId { get; } = prefectureId;
}
