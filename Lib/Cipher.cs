using System;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Lib
{
    public sealed class Cipher : ICipher, IDisposable
    {
        private readonly IConverter _converter;
        private readonly SymmetricAlgorithm _algorithm;

        public Cipher(IConverter converter, IOptions<CipherConfiguration> options)
        {
            _converter = converter;
            _algorithm = GetSymmetricAlgorithm(options);
        }

        public string Name => _algorithm.GetType().Name;

        public string Encrypt(string clearText)
        {
            using var encryptor = _algorithm.CreateEncryptor();
            var clearTextBytes = _converter.ConvertClearTextToBytes(clearText);
            var encryptedBytes = encryptor.TransformFinalBlock(clearTextBytes, 0, clearTextBytes.Length);
            var cipherText = _converter.ConvertEncryptedBytesToCipherText(encryptedBytes);
            return cipherText;
        }

        public string Decrypt(string cipherText)
        {
            var cipherBytes = _converter.ConvertCipherTextToBytes(cipherText);
            using var decryptor = _algorithm.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            var clearText = _converter.ConvertDecryptedBytesToClearText(decryptedBytes);
            return clearText;
        }

        public void Dispose()
        {
            _algorithm?.Dispose();
        }

        private SymmetricAlgorithm GetSymmetricAlgorithm(IOptions<CipherConfiguration> options)
        {
            var algorithm = SymmetricAlgorithm.Create(options.Value.AlgorithmName);
            if (algorithm == null)
            {
                throw CipherException.InvalidAlgorithmName(options.Value.AlgorithmName);
            }

            algorithm.Key = _converter.ConvertSymmetricSecretKey(options.Value.SymmetricSecretKey);
            algorithm.IV = _converter.ConvertInitializationVector(options.Value.InitializationVector);
            return algorithm;
        }
    }
}