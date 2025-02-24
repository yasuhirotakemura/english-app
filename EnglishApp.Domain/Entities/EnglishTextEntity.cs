namespace EnglishApp.Domain.Entities;

public sealed class EnglishTextEntity(int id, string title, string content, DateTime createdAt, DateTime updatedAt)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;
}
