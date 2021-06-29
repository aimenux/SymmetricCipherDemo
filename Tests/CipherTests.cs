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
            var clearText = CipherHelperForTests.RandomString(10);

            // act
            var cipherText = cipher.Encrypt(clearText);
            var outputClearText = cipher.Decrypt(cipherText);

            // assert
            outputClearText.Should().Be(clearText);
        }
    }
}
