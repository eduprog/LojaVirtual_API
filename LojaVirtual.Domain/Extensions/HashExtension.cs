namespace LojaVirtual.Domain.Extensions
{
    public static class HashExtension
    {
        public static string HashBCrypt(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CompareHashBCrypt(this string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
