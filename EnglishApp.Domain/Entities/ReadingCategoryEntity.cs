namespace EnglishApp.Domain.Entities;

public sealed class ReadingCategoryEntity(int id,
                                          string name,
                                          DateTime createdAt,
                                          DateTime updatedAt) : MasterEntityBase(id, name, createdAt, updatedAt)
{
}
