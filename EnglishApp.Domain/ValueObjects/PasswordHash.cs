using EnglishApp.Domain.Logics;
using EnglishApp.Domain.ValueObjects.Bases;

namespace EnglishApp.Domain.ValueObjects;

public sealed class PasswordHash(byte[] hash, byte[] salt) : ValueObject<PasswordHash>
{
    public byte[] Hash { get; } = hash;
    public byte[] Salt { get; } = salt;

    public static PasswordHash CreateFromPlainText(string password)
    {
        byte[] hash = PasswordHasher.HashPassword(password, out byte[] salt);

        return new PasswordHash(hash, salt);
    }

    public static PasswordHash CreateFromBase64(string base64Hash, string base64Salt)
    {
        return new PasswordHash(Convert.FromBase64String(base64Hash), Convert.FromBase64String(base64Salt));
    }

    public string GetBase64Hash() => Convert.ToBase64String(this.Hash);
    public string GetBase64Salt() => Convert.ToBase64String(this.Salt);

    protected override bool EqualsCore(PasswordHash other)
    {
        return this.Hash.SequenceEqual(other.Hash) && this.Salt.SequenceEqual(other.Salt);
    }
}
