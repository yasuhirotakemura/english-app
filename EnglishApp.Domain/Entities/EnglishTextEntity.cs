namespace EnglishApp.Domain.Entities;

public sealed class EnglishTextEntity(int id,
                                string title,
                                string content,
                                DateTime createdAt,
                                DateTime updatedAt)
{
    public int Id = id;
    public string Title = title;
    public string Content = content;
    public DateTime CreatedAt = createdAt;
    public DateTime UpdatedAt = updatedAt;
}