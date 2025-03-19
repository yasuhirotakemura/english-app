using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.StaticValues;

public static class MasterData
{
    public static ImmutableList<PrefectureEntity> Prefectures = [];
    public static ImmutableList<UserGradeEntity> UserGrades = [];
    public static ImmutableList<UserLearningPurposeEntity> UserLearningPurposes = [];

    public static void Update(List<PrefectureEntity> prefectures,
                              List<UserGradeEntity> userGrades,
                              List<UserLearningPurposeEntity> userLearningPurposes)
    {
        Prefectures = [.. prefectures];
        UserGrades = [.. userGrades];
        UserLearningPurposes = [.. userLearningPurposes];
    }
}
