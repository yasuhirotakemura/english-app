namespace EnglishApp.Domain.Entities;

public sealed class PrefectureEntity(int id,
                                     string name,
                                     DateTime createdAt,
                                     DateTime updatedAt) : MasterEntityBase(id, name, createdAt, updatedAt)
{
}