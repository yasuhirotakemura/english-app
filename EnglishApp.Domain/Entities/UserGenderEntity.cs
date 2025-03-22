namespace EnglishApp.Domain.Entities;

public sealed class UserGenderEntity(byte id, string name)
{
    public byte Id { get; } = id;
    public string Name { get; } = name;
}
