using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace EnglishApp.Infrastructure.Factories;

internal static class EntityFactory
{
    public static EnglishTextEntity CreateEnglishText(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetString(reader.GetOrdinal("Title")),
            reader.GetString(reader.GetOrdinal("Content")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static EnglishChoiceQuestionEntity CreateEnglishChoiceQuestionEntity(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetInt32(reader.GetOrdinal("EnglishTextId")),
            reader.GetString(reader.GetOrdinal("QuestionText")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }

    public static T CreateMasterEntity<T>(SqlDataReader reader) where T : IMasterEntity
    {
        int id = reader.GetInt32(reader.GetOrdinal("Id"));
        string name = reader.GetString(reader.GetOrdinal("Name"));

        // コンストラクタを取得してインスタンスを作成
        return (T)Activator.CreateInstance(typeof(T), id, name);
    }
}