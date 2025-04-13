using EnglishApp.Domain.Enums;

namespace EnglishApp.Application.Dtos.Bases;

public sealed class WarningMessage
{
    public string Message { get; init; } = String.Empty;
    public WarningType Type { get; init; } = WarningType.Info;
}
