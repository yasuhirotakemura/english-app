using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.Factories;

public static class ResponseFactory
{
    public static UserProfileSetupResponse CreateUserProfileSetupResponse(string message, UserProfileEntity entity)
    {
        return new UserProfileSetupResponse(
            message: message,
            userId: entity.UserId,
            nickName: entity.NickName,
            gender: entity.Gender,
            gradeId: entity.GradeId,
            learningPurposeId: entity.LearningPurposeId,
            prefectureId: entity.PrefectureId,
            birthDate: entity.BirthDate,
            profileText: entity.ProfileText,
            isDeleted: entity.IsDeleted,
            createdAt: entity.CreatedAt,
            updatedAt: entity.UpdatedAt
        );
    }
}
