namespace EnglishApp.Domain.Entities;

public sealed class EnglishChoiceQuestionEntity(int id,
                                                int englishTextId,
                                                string questionText,
                                                DateTime createdAt,
                                                DateTime updatedAt)
{
    public int Id { get; } = id;

    public int EnglishTextId { get; } = englishTextId;

    public string QuestionText { get; } = questionText;

    public DateTime CreatedAt { get; } = createdAt;

    public DateTime UpdatedAt { get; } = updatedAt;
}
