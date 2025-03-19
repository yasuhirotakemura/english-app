using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.Dtos;

public sealed class MasterDataDto
{
    public List<PrefectureEntity> Prefectures { get; set; } = [];
    public List<UserGradeEntity> UserGrades { get; set; } = [];
    public List<UserLearningPurposeEntity> UserLearningPurposes { get; set; } = [];
}
