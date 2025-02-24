namespace EnglishApp.Domain.Entities;

public sealed class EnglishQuestionEntity(int id, int englishTextId, string questionText, string answer, DateTime createdAt, DateTime updatedAt)
{
    public int Id { get; set; } = id;
    public int EnglishTextId { get; set; } = englishTextId;
    public string QuestionText { get; set; } = questionText;
    public string Answer { get; set; } = answer;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;
}

