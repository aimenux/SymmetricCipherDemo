namespace Lib
{
    public class CipherConfiguration
    {
        public string AlgorithmName { get; set; }

        public string SymmetricSecretKey { get; set; }

        public string InitializationVector { get; set; }
    }
}