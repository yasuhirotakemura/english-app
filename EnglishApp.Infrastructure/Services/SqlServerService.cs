using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Services;

public sealed class SqlServerService
{
    private readonly string _connectionString
        = "Server=JUPITER4823;Database=EnglishApp;Integrated Security=True;TrustServerCertificate=True;\r\n";

    public async Task<ImmutableList<T>> QueryAsync<T>(
        string sql,
        Func<SqlDataReader, T> createEntity)
    {
        return await this.QueryAsync(sql, null, createEntity);
    }

    public async Task<ImmutableList<T>> QueryAsync<T>(
        string sql,
        SqlParameter[]? parameters,
        Func<SqlDataReader, T> createEntity)
    {
        ImmutableList<T>.Builder resultBuilder = ImmutableList.CreateBuilder<T>();

        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new(sql, connection);

        if (parameters is not null)
        {
            command.Parameters.AddRange(parameters);
        }

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            resultBuilder.Add(createEntity(reader));
        }

        return resultBuilder.ToImmutable();
    }

    public async Task<T?> QuerySingleAsync<T>(
        string sql,
        Func<SqlDataReader, T> createEntity)
    {
        return await this.QuerySingleAsync(sql, null, createEntity);
    }

    public async Task<T?> QuerySingleAsync<T>(
        string sql,
        SqlParameter[]? parameters,
        Func<SqlDataReader, T> createEntity)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new(sql, connection);

        if (parameters is not null)
        {
            command.Parameters.AddRange(parameters);
        }

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return createEntity(reader);
        }

        return default;
    }

    public void Execute
        (string insert,
         string update,
         SqlParameter[] parameters)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new(update, connection);

        if (parameters is not null)
        {
            command.Parameters.AddRange(parameters);
        }

        if(command.ExecuteNonQuery() < 1)
        {
            command.CommandText = insert;

            command.ExecuteNonQuery();
        }
    }

    public void Execute
        (string sql,
         SqlParameter[] parameters)
    {
        using SqlConnection connection = new(this._connectionString);
        using SqlCommand command = new(sql, connection);

        if (parameters is not null)
        {
            command.Parameters.AddRange(parameters);
        }

        command.ExecuteNonQuery();
    }
}
