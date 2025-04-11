using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Dtos.Master;

public sealed class UserSetupDataResponse(ImmutableList<PrefectureEntity> prefectures,
                                             ImmutableList<GenderEntity> userGenders,
                                             ImmutableList<GradeEntity> userGrades,
                                             ImmutableList<LearningPurposeEntity> userLearningPurposes,
                                             ImmutableList<IconUri> iconUris)
{
    public ImmutableList<PrefectureEntity> Prefectures { get; } = prefectures;
    public ImmutableList<GenderEntity> Genders { get; } = userGenders;
    public ImmutableList<GradeEntity> Grades { get; } = userGrades;
    public ImmutableList<LearningPurposeEntity> LearningPurposes { get; } = userLearningPurposes;
    public ImmutableList<IconUri> IconUris { get; } = iconUris;
}
