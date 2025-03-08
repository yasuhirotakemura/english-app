using EnglishApp.Domain.Exceptions.Bases;

namespace EnglishApp.Domain.Exceptions;

public sealed class InputException : ExceptionBase
{
    public InputException() : base() { }

    public InputException(string message) : base(message) { }

    public InputException(string? message, Exception? innerException) : base(message, innerException) { }

    public override ExceptionType ExceptionType => ExceptionType.Error;
}
