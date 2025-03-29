namespace EnglishApp.Application;

public class ApiResult<T>
{
    public T? Data { get; }
    public string? ErrorMessage { get; }

    public bool IsSuccess => this.ErrorMessage == null;

    private ApiResult(T? data, string? errorMessage)
    {
        this.Data = data;
        this.ErrorMessage = errorMessage;
    }

    public static ApiResult<T> Success(T data) => new(data, null);
    public static ApiResult<T> Failure(string errorMessage) => new(default, errorMessage);
}
