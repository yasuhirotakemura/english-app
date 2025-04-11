namespace EnglishApp.Domain.Entities;

public abstract class MasterEntityBase(int id,
                                       string name,
                                       DateTime createdAt,
                                       DateTime updatedAt)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public DateTime CreatedAt { get; } = createdAt;
    public DateTime UpdatedAt { get; } = updatedAt;

    public override string ToString() => $"{this.Name} ({this.Id}), \n作成日時: {this.CreatedAt}, \n更新日時: {this.UpdatedAt}";
}
