using System;
using FluentAssertions;
using Lib;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests
{
    public class CipherTests
    {
        [Theory]
        [ClassData(typeof(CipherConfigurationTestCases))]
        public void Should_Encrypt_Decrypt_Data_With_Des(CipherConfiguration configuration)
        {
            // arrange
            var converter = new Converter();
            var options = Options.Create(configuration);
            using var cipher = new Cipher(converter, options);
            var clearText = HelperForTests.RandomString(10);

            // act
            var cipherText = cipher.Encrypt(clearText);
            var outputClearText = cipher.Decrypt(cipherText);

            // assert
            outputClearText.Should().Be(clearText);
        }

        private class CipherConfigurationTestCases : TheoryData<CipherConfiguration>
        {
            public CipherConfigurationTestCases()
            {
                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.DES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(8),
                    InitializationVector = GenerateSymmetricSecretKey(8)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.TripleDES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(16),
                    InitializationVector = GenerateSymmetricSecretKey(8)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.TripleDES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(24),
                    InitializationVector = GenerateSymmetricSecretKey(8)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.Rijndael),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(16),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.RC2),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(16),
                    InitializationVector = GenerateSymmetricSecretKey(8)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(16),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(24),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AES),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(32),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AesManaged),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(16),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AesManaged),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(24),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });

                Add(new CipherConfiguration
                {
                    AlgorithmName = nameof(CipherTypes.AesManaged),
                    SymmetricSecretKey = GenerateSymmetricSecretKey(32),
                    InitializationVector = GenerateSymmetricSecretKey(16)
                });
            }
        }

        private static string GenerateSymmetricSecretKey(int length)
        {
            var bytes = HelperForTests.RandomBytes(length);
            return Convert.ToBase64String(bytes);
        }
    }
}
