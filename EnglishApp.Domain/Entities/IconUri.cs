namespace EnglishApp.Domain.Entities;

public sealed class IconUri(string uri)
{
    public string Uri { get; } = uri;
}
