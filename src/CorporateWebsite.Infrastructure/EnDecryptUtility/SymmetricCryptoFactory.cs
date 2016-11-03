using System.Security.Cryptography;
namespace CorporateWebsite.Infrastructure.EnDecryptUtility
{
    class SymmetricCryptoFactory
    {
        public static SymmetricAlgorithm Create(CipherType cryptoType)
        {
            switch (cryptoType)
            { 
                case CipherType.Des:
                    return DESCryptoServiceProvider.Create();
                case CipherType.TripleDes:
                    return TripleDESCryptoServiceProvider.Create();
                case CipherType.Aes:
                    return AesCryptoServiceProvider.Create();
                default:
                    return DESCryptoServiceProvider.Create();
            }
        }
    }
}
