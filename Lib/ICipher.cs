namespace Lib
{
    public interface ICipher
    {
        string Name { get; }

        string Encrypt(string clearText);

        string Decrypt(string cipherText);
    }
}