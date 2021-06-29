using System.Collections.Generic;
using Lib;
using Microsoft.Extensions.Options;

namespace App
{
    public class Factory : IFactory
    {
        private readonly IConverter _converter;

        public Factory(IConverter converter)
        {
            _converter = converter;
        }

        public IEnumerable<ICipher> GetCiphers()
        {
            yield return new Cipher(_converter, Options.Create(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.DES),
                SymmetricSecretKey = "J0kkFUDBuCM=",
                InitializationVector = "HJZwKWNxiIA="
            }));

            yield return new Cipher(_converter, Options.Create(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.TripleDES),
                SymmetricSecretKey = "xy2nz0GyOTu+y9LvQxPF+A==",
                InitializationVector = "cJ/zyzp7lbI="
            }));

            yield return new Cipher(_converter, Options.Create(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AES),
                SymmetricSecretKey = "xy2nz0GyOTu+y9LvQxPF+A==",
                InitializationVector = "Cy3S1aXjKlrHJ3ZoF+kk3g=="
            }));

            yield return new Cipher(_converter, Options.Create(new CipherConfiguration
            {
                AlgorithmName = nameof(CipherTypes.AesManaged),
                SymmetricSecretKey = "xy2nz0GyOTu+y9LvQxPF+A==",
                InitializationVector = "Cy3S1aXjKlrHJ3ZoF+kk3g=="
            }));
        }
    }

    public interface IFactory
    {
        IEnumerable<ICipher> GetCiphers();
    }
}
