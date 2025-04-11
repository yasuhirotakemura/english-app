using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.StaticValues;

public static class MasterData
{
    public static ImmutableList<PrefectureEntity> Prefectures = [];
    public static ImmutableList<GenderEntity> UserGenders = [];
    public static ImmutableList<GradeEntity> UserGrades = [];
    public static ImmutableList<LearningPurposeEntity> UserLearningPurposes = [];

    public static void Update(List<PrefectureEntity> prefectures,
                              List<GradeEntity> userGrades,
                              List<LearningPurposeEntity> userLearningPurposes)
    {
        Prefectures = [.. prefectures];
        UserGrades = [.. userGrades];
        UserLearningPurposes = [.. userLearningPurposes];
    }
}
