namespace EnglishApp.Domain.Entities;

public sealed class UserGenderEntity(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}
