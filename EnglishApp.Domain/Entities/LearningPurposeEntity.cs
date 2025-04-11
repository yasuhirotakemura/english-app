namespace EnglishApp.Domain.Entities;

public sealed class LearningPurposeEntity(int id,
                                              string name,
                                              DateTime createdAt,
                                              DateTime updatedAt) : MasterEntityBase(id, name, createdAt, updatedAt)
{
}
