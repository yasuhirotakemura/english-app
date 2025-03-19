using EnglishApp.Domain.Interfaces;

namespace EnglishApp.Domain.Entities;

public sealed class UserLearningPurposeEntity(int id, string name) : IMasterEntity
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}
