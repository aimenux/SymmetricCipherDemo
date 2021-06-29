using System;
using System.Linq;

namespace Tests
{
    public static class CipherHelperForTests
    {
        private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

        public static string RandomString(int length)
        {
            const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static byte[] RandomBytes(int length)
        {
            var bytes = new byte[length];
            Random.NextBytes(bytes);
            return bytes;
        }

        public static string RandomSymmetricSecretKey(int length) => RandomBase64String(length);

        public static string RandomInitializationVector(int length) => RandomBase64String(length);

        private static string RandomBase64String(int length)
        {
            var bytes = RandomBytes(length);
            return Convert.ToBase64String(bytes);
        }
    }
}
