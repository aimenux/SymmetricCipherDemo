using System;
using System.Linq;

namespace Tests
{
    public static class HelperForTests
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
    }
}
