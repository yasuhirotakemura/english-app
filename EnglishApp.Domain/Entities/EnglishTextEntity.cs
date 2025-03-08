namespace EnglishApp.Domain.Entities;

public sealed class EnglishTextEntity(int id, string title, string content, DateTime createdAt, DateTime updatedAt)
{
    public int Id { get; } = id;
    public string Title { get; } = title;
    public string Content { get; } = content;
    public DateTime CreatedAt { get; } = createdAt;
    public DateTime UpdatedAt { get; } = updatedAt;
}
