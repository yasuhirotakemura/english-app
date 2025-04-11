using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Dtos.Master;

public sealed class MasterDataResponse(ImmutableList<PrefectureEntity> prefectures,
                                       ImmutableList<UserGenderEntity> userGenders,
                                       ImmutableList<UserGradeEntity> userGrades,
                                       ImmutableList<UserLearningPurposeEntity> userLearningPurposes)
{
    public ImmutableList<PrefectureEntity> Prefectures { get; } = prefectures;
    public ImmutableList<UserGenderEntity> UserGenders { get; } = userGenders;
    public ImmutableList<UserGradeEntity> UserGrades { get; } = userGrades;
    public ImmutableList<UserLearningPurposeEntity> UserLearningPurposes { get; } = userLearningPurposes;
}
