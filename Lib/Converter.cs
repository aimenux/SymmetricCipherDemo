using System;
using System.Text;

namespace Lib
{
    public class Converter : IConverter
    {
        public byte[] ConvertClearTextToBytes(string clearText) => Encoding.UTF8.GetBytes(clearText);

        public byte[] ConvertCipherTextToBytes(string cipherText) => Convert.FromBase64String(cipherText);

        public string ConvertEncryptedBytesToCipherText(byte[] encryptedBytes) => Convert.ToBase64String(encryptedBytes);

        public string ConvertDecryptedBytesToClearText(byte[] decryptedBytes) => Encoding.UTF8.GetString(decryptedBytes);

        public byte[] ConvertSymmetricSecretKey(string symmetricSecretKey) => Convert.FromBase64String(symmetricSecretKey);

        public byte[] ConvertInitializationVector(string initializationVector) => Convert.FromBase64String(initializationVector);
    }
}