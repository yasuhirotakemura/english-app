using System.Security.Cryptography;
using System.Text;

namespace EnglishApp.Domain.Logics;

public static class PasswordHasher
{
    public static byte[] HashPassword(string password, out byte[] salt)
    {
        salt = GenerateSalt();
        return HashPassword(password, salt);
    }

    private static byte[] HashPassword(string password, byte[] salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password); // 文字列PWをUTF-8エンコーディングでbyte配列にする
            byte[] combined = [.. passwordBytes, .. salt]; // byte配列PWにSaltを結合
            byte[] hashBytes = sha256.ComputeHash(combined); // ハッシュ値を作成

            return hashBytes;
        }
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }
}
