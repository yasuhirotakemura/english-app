using EnglishApp.Domain.Exceptions.Bases;

namespace EnglishApp.Domain.Exceptions;

public sealed class EmailNotFoundException : ExceptionBase
{
    public EmailNotFoundException() : base() { }

    public EmailNotFoundException(string message) : base(message) { }

    public EmailNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    public override ExceptionType ExceptionType => ExceptionType.Error;
}
