﻿using EnglishApp.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace EnglishApp.Infrastructure.Factories;

internal static class EntityFactory
{
    public static UserProfileEntity CreateUserProfileEntity(SqlDataReader reader)
    {
        return new UserProfileEntity(
            userId: reader.GetInt32(reader.GetOrdinal("UserId")),
            nickName: reader.GetString(reader.GetOrdinal("NickName")),
            genderId: reader.GetInt32(reader.GetOrdinal("Gender")),
            gradeId: reader.GetInt32(reader.GetOrdinal("GradeId")),
            learningPurposeId: reader.GetInt32(reader.GetOrdinal("LearningPurposeId")),
            prefectureId: reader.GetInt32(reader.GetOrdinal("PrefectureId")),
            grade: reader.GetString(reader.GetOrdinal("Grade")),
            learningPurpose: reader.GetString(reader.GetOrdinal("LearningPurpose")),
            prefecture: reader.GetString(reader.GetOrdinal("Prefecture")),
            birthDate: reader.IsDBNull(reader.GetOrdinal("BirthDate"))
                        ? null
                        : reader.GetDateTime(reader.GetOrdinal("BirthDate")),
            profileText: reader.IsDBNull(reader.GetOrdinal("ProfileText"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("ProfileText")),
            isDeleted: reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
            accountCreatedAt: reader.GetDateTime(reader.GetOrdinal("AccountCreatedAt")),
            profileUpdatedAt: reader.GetDateTime(reader.GetOrdinal("ProfileUpdatedAt")),
            lastLoginAt: reader.GetDateTime(reader.GetOrdinal("LastLoginAt")),
            iconUri: reader.GetString(reader.GetOrdinal("IconUri"))
        );
    }

    public static UserSignInEntity CreateUserSignInEntity(SqlDataReader reader)
    {
        return new
        (
            userId: reader.GetInt32(reader.GetOrdinal("UserId")),
            nickName: reader.GetString(reader.GetOrdinal("NickName")),
            isEmailVerified: reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"))
         );
    }


    public static T CreateMasterEntitiy<T>(SqlDataReader reader, Func<int, string, DateTime, DateTime, T> constructor)
        where T : MasterEntityBase
    {
        return constructor(
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    // --- 以下のマスタメソッドは改善しないと。 ---
    public static GenderEntity CreateUserGenderEntity(SqlDataReader reader)
    {
        return new
        (
            id: reader.GetInt32(reader.GetOrdinal("Id")),
            name: reader.GetString(reader.GetOrdinal("Name")),
            createdAt: reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            updatedAt: reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static GradeEntity CreateUserGradeEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static LearningPurposeEntity CreateUserLearningPurposeEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static PrefectureEntity CreatePrefectureEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static ReadingLevelEntity CreateReadingLevelEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static ExamLevelEntity CreateExamLevelEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static ReadingCategoryEntity CreateReadingCategoryEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Name")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }
    // ------
}