namespace EnglishApp.Domain.Entities;

public sealed class UserGradeEntity(int id,
                                     string name,
                                     DateTime createdAt,
                                     DateTime updatedAt) : MasterEntityBase(id, name, createdAt, updatedAt)
{
}
