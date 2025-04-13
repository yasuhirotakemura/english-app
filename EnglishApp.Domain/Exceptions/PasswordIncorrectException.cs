using EnglishApp.Domain.Exceptions.Bases;

namespace EnglishApp.Domain.Exceptions;

public sealed class PasswordIncorrectException : ExceptionBase
{
    public PasswordIncorrectException()
    {
    }

    public PasswordIncorrectException(string? message) : base(message)
    {
    }

    public PasswordIncorrectException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public override ExceptionType ExceptionType => ExceptionType.Error;
}