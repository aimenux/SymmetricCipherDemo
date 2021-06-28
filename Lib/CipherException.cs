using System;
using System.Runtime.Serialization;

namespace Lib
{
    [Serializable]
    public class CipherException : Exception
    {
        protected CipherException(string message) : base(message)
        {
        }

        protected CipherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static CipherException InvalidAlgorithmName(string algorithmName)
        {
            return new CipherException($"Invalid algorithm name {algorithmName}");
        }
    }
}
