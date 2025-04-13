using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Dtos.UserProfile;

public sealed class UserSetupDataResponse(ImmutableList<PrefectureEntity> prefectures,
                                             ImmutableList<GenderEntity> genders,
                                             ImmutableList<GradeEntity> grades,
                                             ImmutableList<LearningPurposeEntity> learningPurposes,
                                             ImmutableList<IconUri> iconUris)
{
    public ImmutableList<PrefectureEntity> Prefectures { get; } = prefectures;
    public ImmutableList<GenderEntity> Genders { get; } = genders;
    public ImmutableList<GradeEntity> Grades { get; } = grades;
    public ImmutableList<LearningPurposeEntity> LearningPurposes { get; } = learningPurposes;
    public ImmutableList<IconUri> IconUris { get; } = iconUris;
}
