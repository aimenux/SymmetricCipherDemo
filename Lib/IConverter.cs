namespace Lib
{
    public interface IConverter
    {
        byte[] ConvertClearTextToBytes(string clearText);

        byte[] ConvertCipherTextToBytes(string cipherText);

        string ConvertEncryptedBytesToCipherText(byte[] encryptedBytes);

        string ConvertDecryptedBytesToClearText(byte[] decryptedBytes);

        byte[] ConvertSymmetricSecretKey(string symmetricSecretKey);

        byte[] ConvertInitializationVector(string initializationVector);
    }
}