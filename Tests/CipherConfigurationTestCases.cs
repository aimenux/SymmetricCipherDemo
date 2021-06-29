using Lib;
using Xunit;
using static Tests.CipherHelperForTests;

namespace Tests
{
    public class CipherConfigurationTestCases : TheoryData<CipherConfiguration>
    {
        public CipherConfigurationTestCases()
        {
            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.DES),
                SymmetricSecretKey = RandomSymmetricSecretKey(8),
                InitializationVector = RandomInitializationVector(8)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.TripleDES),
                SymmetricSecretKey = RandomSymmetricSecretKey(16),
                InitializationVector = RandomInitializationVector(8)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.TripleDES),
                SymmetricSecretKey = RandomSymmetricSecretKey(24),
                InitializationVector = RandomInitializationVector(8)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.Rijndael),
                SymmetricSecretKey = RandomSymmetricSecretKey(16),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.RC2),
                SymmetricSecretKey = RandomSymmetricSecretKey(16),
                InitializationVector = RandomInitializationVector(8)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AES),
                SymmetricSecretKey = RandomSymmetricSecretKey(16),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AES),
                SymmetricSecretKey = RandomSymmetricSecretKey(24),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AES),
                SymmetricSecretKey = RandomSymmetricSecretKey(32),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AesManaged),
                SymmetricSecretKey = RandomSymmetricSecretKey(16),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AesManaged),
                SymmetricSecretKey = RandomSymmetricSecretKey(24),
                InitializationVector = RandomInitializationVector(16)
            });

            Add(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AesManaged),
                SymmetricSecretKey = RandomSymmetricSecretKey(32),
                InitializationVector = RandomInitializationVector(16)
            });
        }
    }
}