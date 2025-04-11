using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Services;

public sealed class SqlServerService(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public async Task<ImmutableList<T>> QueryAsync<T>(string sql,
                                                      Func<SqlDataReader, T> createEntity)
    {
        return await this.QueryAsync(sql, null, createEntity);
    }

    public async Task<ImmutableList<T>> QueryAsync<T>(string sql,
                                                      SqlParameter[]? parameters,
                                                      Func<SqlDataReader, T> createEntity)
    {
        ImmutableList<T>.Builder resultBuilder = ImmutableList.CreateBuilder<T>();

        using (SqlConnection connection = new(this._connectionString))
        using (SqlCommand command = new(sql, connection))
        {
            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    resultBuilder.Add(createEntity(reader));
                }
            }
        }

        return resultBuilder.ToImmutable();
    }

    public async Task<T?> QuerySingleAsync<T>(string sql,
                                              Func<SqlDataReader, T> createEntity)
    {
        return await this.QuerySingleAsync(sql, null, createEntity);
    }

    public async Task<T?> QuerySingleAsync<T>(string sql,
                                              SqlParameter[]? parameters,
                                              Func<SqlDataReader, T> createEntity)
    {
        using (SqlConnection connection = new(this._connectionString))
        using (SqlCommand command = new(sql, connection))
        {
            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return createEntity(reader);
                }
            }
        }
        
        return default;
    }

    public void Execute(string insert,
                        string update,
                        SqlParameter[] parameters)
    {
        using (SqlConnection connection = new(this._connectionString))
        using (SqlCommand command = new(update, connection))
        {
            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.OpenAsync();

            if (command.ExecuteNonQuery() < 1)
            {
                command.CommandText = insert;

                command.ExecuteNonQuery();
            }
        }
    }

    public async Task<int> ExecuteAsync(string sql,
                        SqlParameter[] parameters)
    {
        using (SqlConnection connection = new(this._connectionString))
        using (SqlCommand command = new(sql, connection))
        {
            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            return await command.ExecuteNonQueryAsync();
        }
    }

    public async Task<object?> ExecuteScalarAsync(string sql, SqlParameter[]? parameters = null)
    {
        using (SqlConnection connection = new(this._connectionString))
        using (SqlCommand command = new(sql, connection))
        {
            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            return await command.ExecuteScalarAsync();
        }
    }
}
