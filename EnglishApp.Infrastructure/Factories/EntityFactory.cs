using EnglishApp.Domain.Entities;
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

    public static EnglishQuestionEntity CreateEnglishQuestion(SqlDataReader reader)
    {
        return new
        (
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetInt32(reader.GetOrdinal("EnglishTextId")),
            reader.GetString(reader.GetOrdinal("QuestionText")),
            reader.GetString(reader.GetOrdinal("Answer")),
            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
        );
    }
}